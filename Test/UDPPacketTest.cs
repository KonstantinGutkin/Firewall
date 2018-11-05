using NUnit.Framework;

namespace FirewallTests
{
    using lab4.Network;
    [TestFixture]
    class UDPPacketTest
    {
        [Test]
        public void TestCopyUDPPackets() {
            UDPPacket packetSrc = new UDPPacket();
            UDPPacket packetDst = new UDPPacket();
            packetSrc.SrcMAC =
                new PhysicalAddress(new byte[] { 0x11, 0x22, 0x33, 0x44, 0x55, 0x66 });
            packetSrc.DstMAC =
                new PhysicalAddress(new byte[] { 0x66, 0x55, 0x44, 0x33, 0x22, 0x11 });
            packetSrc.SrcIP = new NetworkAddress("127.0.0.1");
            packetSrc.DstIP = new NetworkAddress("1.1.1.1");
            packetSrc.DstPort = 1234;
            packetSrc.SrcPort = 123;
            packetSrc.Data[0] = 1;
            packetSrc.Data[1] = 2;
            packetSrc.Copy(packetDst);
            Assert.AreEqual(packetSrc, packetDst);
            Assert.AreNotSame(packetSrc, packetDst);
        }
    }
}
