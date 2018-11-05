using NUnit.Framework;
namespace FirewallTests
{
    using lab4.Network;
    [TestFixture]
    class IPPacketTest
    {
        [Test]
        public void TestCopyIPPackets() {
            IPPacket ipPacketSrc = new IPPacket();
            IPPacket ipPacketDst = new IPPacket();
            ipPacketSrc.SrcMAC =
                new PhysicalAddress(new byte[] { 0x11, 0x22, 0x33, 0x44, 0x55, 0x66 });
            ipPacketSrc.DstMAC = 
                new PhysicalAddress(new byte[] { 0x66, 0x55, 0x44, 0x33, 0x22, 0x11 });
            ipPacketSrc.SrcIP = new NetworkAddress("127.0.0.1");
            ipPacketSrc.DstIP = new NetworkAddress("1.1.1.1");
            ipPacketSrc.Copy(ipPacketDst);
            Assert.AreEqual(ipPacketDst, ipPacketSrc);
            Assert.AreNotSame(ipPacketDst, ipPacketSrc);
        }
    }
}
