using NUnit.Framework;
using TestStack.BDDfy;

namespace FirewallTests
{
    using lab4.Network.Safety;
    using lab4.Network;
    class NATCommandTest
    {
        IPPacket packetWithSrcIP192_168_0_1, packetWithDstIP1_0_0_5, 
            otherPacket;
        Firewall fw;
        NATCommand natCmd;
        void GivenInitializeFirewall() {
            fw = new Firewall(new FilterMock(), new DistributorMock());
        }
        void AndGivenInitializeFilterCommand() {
            natCmd = new NATCommand();
        }
        void GivenIPPacketWithSrcIP192_168_0_1() {
            packetWithSrcIP192_168_0_1 = new IPPacket();
            packetWithSrcIP192_168_0_1.SrcIP = new NetworkAddress("192.168.0.1");
            packetWithSrcIP192_168_0_1.DstIP = new NetworkAddress("2.3.4.1");    
        }
        void GivenIPPacketWithDstIp1_0_0_5() {
            packetWithDstIP1_0_0_5 = new IPPacket();
            packetWithDstIP1_0_0_5.SrcIP = new NetworkAddress("5.2.8.6");
            packetWithDstIP1_0_0_5.DstIP = new NetworkAddress("1.0.0.5");
        }
        void GivenOtherIpPacket() {
            otherPacket = new IPPacket();
            otherPacket.SrcIP = new NetworkAddress("1.2.3.4");
            otherPacket.DstIP = new NetworkAddress("4.3.2.1");
        }
        void WhenUserAdd192_168_0_1And1_0_0_1AddrsToNatTable() {
            fw.AddAddrsToTableNAT(new NetworkAddress("192.168.0.1"),
                new NetworkAddress("1.0.0.1"));
        }
        void WhenUserAdd192_168_0_5And1_0_0_5AddrsToNatTable() {
            fw.AddAddrsToTableNAT(new NetworkAddress("192.168.0.5"),
                new NetworkAddress("1.0.0.5"));
        }
        void ThenPacketWithSrcAddr192_168_0_1WillHasSrcAddr1_0_0_1() {
           NetworkPacket translatePacket =
                natCmd.DoWithPacket(fw, packetWithSrcIP192_168_0_1);
            Assert.AreEqual((translatePacket as IPPacket).SrcIP,
                new NetworkAddress("1.0.0.1"));
        }
        void ThenPacketWithDstAddr1_0_0_5WillHasDstAddr192_168_0_5() {
            NetworkPacket translatePacket =
                natCmd.DoWithPacket(fw, packetWithDstIP1_0_0_5);
            Assert.AreEqual((translatePacket as IPPacket).DstIP,
                new NetworkAddress("192.168.0.5"));
        }
        void ThenPacketWithOtherAddrWillNotChange() {
            NetworkPacket translatePacket =
                natCmd.DoWithPacket(fw, otherPacket);
            Assert.AreEqual((translatePacket as IPPacket).SrcIP,
                new NetworkAddress("1.2.3.4"));
            Assert.AreEqual((translatePacket as IPPacket).DstIP,
                new NetworkAddress("4.3.2.1"));
        }
        [Test]
        public void TestNatCommand() {
            this.Given(s => s.GivenInitializeFirewall())
                    .And(s => s.AndGivenInitializeFilterCommand())
                    .And(s => s.GivenIPPacketWithDstIp1_0_0_5())
                    .And(s => s.GivenIPPacketWithSrcIP192_168_0_1())
                    .And(s => s.GivenOtherIpPacket())
                .When(s => s.WhenUserAdd192_168_0_1And1_0_0_1AddrsToNatTable())
                    .And(s => s.WhenUserAdd192_168_0_5And1_0_0_5AddrsToNatTable())
                .Then(s => s.ThenPacketWithDstAddr1_0_0_5WillHasDstAddr192_168_0_5())
                    .And(s => s.ThenPacketWithSrcAddr192_168_0_1WillHasSrcAddr1_0_0_1())
                    .And(s => s.ThenPacketWithOtherAddrWillNotChange())
                .BDDfy();
        }
    }
}
