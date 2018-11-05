using NUnit.Framework;

namespace FirewallTests
{
    using lab4.Network;
    [TestFixture]
    class ICMPPacketConverterTest
    {
        
        [Test]
        public void TestICMPConverterFromBytesToObject() {
            byte[] binPacket = new byte[ICMPPacket.Size];
            //Source MAC
            binPacket[0] = 0x11;
            binPacket[1] = 0x22;
            binPacket[2] = 0x33;
            binPacket[3] = 0x44;
            binPacket[4] = 0x55;
            binPacket[5] = 0x66;
            //Destination MAC
            binPacket[6] = 0x66;
            binPacket[7] = 0x55;
            binPacket[8] = 0x44;
            binPacket[9] = 0x33;
            binPacket[10] = 0x22;
            binPacket[11] = 0x11;
            //Source IP
            binPacket[12] = 127;
            binPacket[13] = 0;
            binPacket[14] = 0;
            binPacket[15] = 1;
            //Destination IP
            binPacket[16] = 1;
            binPacket[17] = 1;
            binPacket[18] = 1;
            binPacket[19] = 1;
            //Type
            binPacket[20] = 10;
            //Code
            binPacket[21] = 2;
            //Data
            binPacket[22] = 1;
            binPacket[23] = 2;

            ICMPPacket packet = new ICMPPacket();
            packet.SrcMAC =
               new PhysicalAddress(new byte[] { 0x11, 0x22, 0x33, 0x44, 0x55, 0x66 });
            packet.DstMAC =
                new PhysicalAddress(new byte[] { 0x66, 0x55, 0x44, 0x33, 0x22, 0x11 });
            packet.SrcIP = new NetworkAddress("127.0.0.1");
            packet.DstIP = new NetworkAddress("1.1.1.1");
            packet.Type = 10;
            packet.Code = 2;
            packet.Data[0] = 1;
            packet.Data[1] = 2;

            IcmpPacketConverter converter = new IcmpPacketConverter();
            ICMPPacket convertedPacket = (ICMPPacket) converter.ConvertPacket(binPacket);
            Assert.AreEqual(packet, convertedPacket);
        }

        [Test]
        public void TestIPConverterFromObjectToBytes() {
            byte[] binPacket = new byte[ICMPPacket.Size];
            //Source MAC
            binPacket[0] = 0x11;
            binPacket[1] = 0x22;
            binPacket[2] = 0x33;
            binPacket[3] = 0x44;
            binPacket[4] = 0x55;
            binPacket[5] = 0x66;
            //Destination MAC
            binPacket[6] = 0x66;
            binPacket[7] = 0x55;
            binPacket[8] = 0x44;
            binPacket[9] = 0x33;
            binPacket[10] = 0x22;
            binPacket[11] = 0x11;
            //Source IP
            binPacket[12] = 127;
            binPacket[13] = 0;
            binPacket[14] = 0;
            binPacket[15] = 1;
            //Destination IP
            binPacket[16] = 1;
            binPacket[17] = 1;
            binPacket[18] = 1;
            binPacket[19] = 1;
            //Type
            binPacket[20] = 10;
            //Code
            binPacket[21] = 2;
            //Data
            binPacket[22] = 1;
            binPacket[23] = 2;

            ICMPPacket packet = new ICMPPacket();
            packet.SrcMAC =
               new PhysicalAddress(new byte[] { 0x11, 0x22, 0x33, 0x44, 0x55, 0x66 });
            packet.DstMAC =
                new PhysicalAddress(new byte[] { 0x66, 0x55, 0x44, 0x33, 0x22, 0x11 });
            packet.SrcIP = new NetworkAddress("127.0.0.1");
            packet.DstIP = new NetworkAddress("1.1.1.1");
            packet.Type = 10;
            packet.Code = 2;
            packet.Data[0] = 1;
            packet.Data[1] = 2;

            IcmpPacketConverter converter = new IcmpPacketConverter();
            byte[] convertedBinPacket = converter.ConvertPacket(packet);
            Assert.AreEqual(convertedBinPacket, binPacket);
        }
    }
}
