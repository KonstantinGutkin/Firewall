using NUnit.Framework;

namespace FirewallTests
{
    using lab4.Network;
    [TestFixture]
    class VirtualTrafficsSnifferTest
    {
        VirtualTrafficsSniffer _sniffer;

        [TestFixtureSetUp]
        public void SetUp() {
            _sniffer = new VirtualTrafficsSniffer(
                new lab4.HelperClasses.TrafficGenerator(1000, new NetworkAddress(new byte[4]),
                    new NetworkAddress(new byte[4])));
        }

        [Test]
        public void TestGetIPPacketToVirtualSniffer() {
            byte[] binPacket = new byte[IPPacket.Size];
            NetworkPacket pack = _sniffer.GetPacket(binPacket);
            Assert.IsNotNull(pack as IPPacket);
        }

        [Test]
        public void TestGetUDPPacketToVirtualSniffer() {
            byte[] binPacket = new byte[UDPPacket.Size];
            NetworkPacket pack = _sniffer.GetPacket(binPacket);
            Assert.IsNotNull(pack as UDPPacket);
        }

        [Test]
        public void TestGetTCPPacketToVirtualSniffer() {
            byte[] binPacket = new byte[TCPPacket.Size];
            NetworkPacket pack = _sniffer.GetPacket(binPacket);
            Assert.IsNotNull(pack as TCPPacket);
        }

        [Test]
        public void TestGetICMPPacketToVirtualSniffer() {
            byte[] binPacket = new byte[ICMPPacket.Size];
            NetworkPacket pack = _sniffer.GetPacket(binPacket);
            Assert.IsNotNull(pack as ICMPPacket);            
        }

        [Test]
        public void TestGetFailWhenPacketHasSize6ToVirtualSniffer() {
            byte[] binPacket = new byte[6];
            NetworkPacket pack = _sniffer.GetPacket(binPacket);
            Assert.IsNull(pack);
        }
        
    }
}
