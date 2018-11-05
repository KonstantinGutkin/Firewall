using TestStack.BDDfy;
using NUnit.Framework;

namespace FirewallTests
{
    using lab4.Network.Safety;
    using lab4.Network;    
    class FilterCommandTest
    {
        UDPPacket[] udpPackets;
        TCPPacket[] tcpPackets;
        ICMPPacket[] icmpPackets;
        IPPacket[] ipPackets;
        Firewall fw;
        FilterCommand frCmd;
        void GivenInitializeFirewall() {
            fw = new Firewall(new FilterMock(), new DistributorMock());
        }
        void AndGivenInitializeFilterCommand() {
            frCmd = new FilterCommand();
        }
        void Given5UdpPacketsAnd2IcmpPackets() {
            udpPackets = new UDPPacket[5];
            UDPPacket udpPacket = new UDPPacket();
            udpPacket.SrcIP = new NetworkAddress("1.2.3.4");
            udpPacket.DstIP = new NetworkAddress("4.3.2.1");
            udpPackets[0] = udpPacket;
            udpPackets[1] = udpPacket;
            udpPackets[2] = udpPacket;
            udpPackets[3] = udpPacket;
            udpPackets[4] = udpPacket;
            icmpPackets = new ICMPPacket[2];
            icmpPackets[0] = new ICMPPacket();
            icmpPackets[1] = new ICMPPacket();
            icmpPackets[0].SrcIP = new NetworkAddress("1.2.3.4");
            icmpPackets[0].DstIP = new NetworkAddress("4.3.2.1");
            icmpPackets[1].SrcIP = new NetworkAddress("1.2.3.4");
            icmpPackets[1].DstIP = new NetworkAddress("4.3.2.1");
        }
        void GivenTcpPacketWithDstPort9999AndOtherTcpPacket() {
            tcpPackets = new TCPPacket[2];
            TCPPacket packetWithPortDstIs9999 = new TCPPacket();
            TCPPacket otherPacket = new TCPPacket();
            packetWithPortDstIs9999.DstPort = 9999;
            packetWithPortDstIs9999.SrcIP = new NetworkAddress("1.2.3.4");
            packetWithPortDstIs9999.DstIP = new NetworkAddress("4.3.2.1");
            otherPacket.SrcIP = new NetworkAddress("1.2.3.4");
            otherPacket.DstIP = new NetworkAddress("4.3.2.1");
            otherPacket.DstPort = 1234;
            tcpPackets[0] = packetWithPortDstIs9999;
            tcpPackets[1] = otherPacket;
        }
        void GivenIcmpPacketWithIPDstIs1_1_1_1AndOtherAddr() {
            icmpPackets = new ICMPPacket[2];
            ICMPPacket packetWithIPDst1_1_1_1 = new ICMPPacket();
            ICMPPacket otherPacket = new ICMPPacket();
            packetWithIPDst1_1_1_1.SrcIP = new NetworkAddress("1.2.3.4");
            otherPacket.SrcIP = new NetworkAddress("1.2.3.4");
            otherPacket.DstIP = new NetworkAddress("4.3.2.1");
            packetWithIPDst1_1_1_1.DstIP = new NetworkAddress("1.1.1.1");
            icmpPackets[0] = packetWithIPDst1_1_1_1;
            icmpPackets[1] = otherPacket;
        }
        void GivenIpPacketWithSrcIpIs127_0_0_1AndIpPacketWithOtherAddrs() {
            ipPackets = new IPPacket[2];
            IPPacket packetWithIPSrc127_0_0_1 = new IPPacket();
            IPPacket otherPacket = new IPPacket();
            otherPacket.SrcIP = new NetworkAddress("1.2.3.4");
            otherPacket.DstIP = new NetworkAddress("4.3.2.1");
            packetWithIPSrc127_0_0_1.SrcIP = new NetworkAddress("127.0.0.1");
            packetWithIPSrc127_0_0_1.DstIP = new NetworkAddress("4.3.2.1");
            ipPackets[0] = packetWithIPSrc127_0_0_1;
            ipPackets[1] = otherPacket;
        }
        void WhenUserSetFilterOnUdpProtocol() {
            fw.Filter.Protocols.Add("udp");
        }
        void WhenUserSetFilterOnPortsDstIs9999() {
            fw.Filter.PortsDst.Add(9999);
        }
        void WhenUserSetFilterOnIPAddrSrcIs127_0_0_1() {
            fw.Filter.IPAddrsSrc.Add(new NetworkAddress("127.0.0.1"));
        }
        void WhenUserSetFilterOnIPAddrDstIs1_1_1_1() {
            fw.Filter.IPAddrsDst.Add(new NetworkAddress("1.1.1.1"));
        }
        void ThenAllUdpPacketAreBlockedButIcmpPacketsNo() {
            NetworkPacket[] filteredPackets = new NetworkPacket[5];
            for(int i = 0; i < udpPackets.Length; i++) {
                filteredPackets[i] = frCmd.DoWithPacket(fw, udpPackets[i]);
            }
            foreach(var filteredPacket in filteredPackets) {
                Assert.IsNull(filteredPacket);
            }
        }
        void ThenPacketWithPortDst9999IsBlocked() {
            NetworkPacket[] filteredPackets = new NetworkPacket[tcpPackets.Length];
            for (int i = 0; i < tcpPackets.Length; i++) {
                filteredPackets[i] = frCmd.DoWithPacket(fw, tcpPackets[i]);
            }
            Assert.IsNull(filteredPackets[0]);
            Assert.IsNotNull(filteredPackets[1]);
        }
        void ThenPacketWithSrcIp127_0_0_1IsBlocked() {
            NetworkPacket[] filteredPackets = new NetworkPacket[ipPackets.Length];
            for (int i = 0; i < ipPackets.Length; i++) {
                filteredPackets[i] = frCmd.DoWithPacket(fw, ipPackets[i]);
            }
            Assert.IsNull(filteredPackets[0]);
            Assert.IsNotNull(filteredPackets[1]);
        }
        void ThenPacketWithDstIp1_1_1_1IsBlocked() {
            NetworkPacket[] filteredPackets = new NetworkPacket[icmpPackets.Length];
            for (int i = 0; i < icmpPackets.Length; i++) {
                filteredPackets[i] = frCmd.DoWithPacket(fw, icmpPackets[i]);
            }
            Assert.IsNull(filteredPackets[0]);
            Assert.IsNotNull(filteredPackets[1]);
        }
        [Test]
        public void TestFilterOnUdpProtocol() {
            this.Given(s => s.GivenInitializeFirewall())
                    .And(s => s.AndGivenInitializeFilterCommand())
                    .And(s => s.Given5UdpPacketsAnd2IcmpPackets())
                .When(s => s.WhenUserSetFilterOnUdpProtocol())
                .Then(s => s.ThenAllUdpPacketAreBlockedButIcmpPacketsNo())
                .BDDfy();  
        }
        [Test]
        public void TestFilterOnSrcIp() {
            this.Given(s => s.GivenInitializeFirewall())
                    .And(s => s.AndGivenInitializeFilterCommand())
                    .And(s => s.GivenIpPacketWithSrcIpIs127_0_0_1AndIpPacketWithOtherAddrs())
                .When(s => s.WhenUserSetFilterOnIPAddrSrcIs127_0_0_1())
                .Then(s => s.ThenPacketWithSrcIp127_0_0_1IsBlocked())
                .BDDfy();
        }
        [Test]
        public void TestFilterOnDstIp() {
            this.Given(s => s.GivenInitializeFirewall())
                    .And(s => s.AndGivenInitializeFilterCommand())
                    .And(s => s.GivenIcmpPacketWithIPDstIs1_1_1_1AndOtherAddr())
                .When(s => s.WhenUserSetFilterOnIPAddrDstIs1_1_1_1())
                .Then(s => s.ThenPacketWithDstIp1_1_1_1IsBlocked())
                .BDDfy();
        }
        [Test]
        public void TestFilterOnDstPort() {
            this.Given(s => s.GivenInitializeFirewall())
                    .And(s => s.AndGivenInitializeFilterCommand())
                    .And(s => s.GivenTcpPacketWithDstPort9999AndOtherTcpPacket())
                .When(s => s.WhenUserSetFilterOnPortsDstIs9999())
                .Then(s => s.ThenPacketWithPortDst9999IsBlocked())
                .BDDfy();
        }
    }
}
