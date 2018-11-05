using NUnit.Framework;
namespace FirewallTests
{
    using lab4.Network;
    [TestFixture]
    class ICMPPacketTest
    {
        [Test]
        public void TestCopyICMPPacket() {
            ICMPPacket packetSrc = new ICMPPacket();
            ICMPPacket packetDst = new ICMPPacket();            
            packetSrc.SrcMAC =
                new PhysicalAddress(new byte[] { 0x11, 0x22, 0x33, 0x44, 0x55, 0x66 });
            packetSrc.DstMAC =
                new PhysicalAddress(new byte[] { 0x66, 0x55, 0x44, 0x33, 0x22, 0x11 });
            packetSrc.SrcIP = new NetworkAddress("127.0.0.1");
            packetSrc.DstIP = new NetworkAddress("1.1.1.1");
            packetSrc.Type = 10;
            packetSrc.Code = 1;
            packetSrc.Data[0] = 1;
            packetSrc.Data[1] = 0x33;
            packetSrc.Copy(packetDst);
            Assert.AreEqual(packetSrc, packetDst);
            Assert.AreNotSame(packetSrc, packetDst);
        }
    }
}
