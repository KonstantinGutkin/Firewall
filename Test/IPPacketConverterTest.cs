using NUnit.Framework;

namespace FirewallTests
{
    using lab4.Network;
    [TestFixture]
    class IPPacketConverterTest
    {
        [Test]
        public void TestIPConverterFromBytesToObject() {
            byte[] binPacket = new byte[IPPacket.Size];
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

            IPPacket packet = new IPPacket();
            packet.SrcMAC =
               new PhysicalAddress(new byte[] { 0x11, 0x22, 0x33, 0x44, 0x55, 0x66 });
            packet.DstMAC =
                new PhysicalAddress(new byte[] { 0x66, 0x55, 0x44, 0x33, 0x22, 0x11 });
            packet.SrcIP = new NetworkAddress("127.0.0.1");
            packet.DstIP = new NetworkAddress("1.1.1.1");

            IPPacketConverter converter = new IPPacketConverter();
            IPPacket convertedPacket = (IPPacket)converter.ConvertPacket(binPacket);
            Assert.AreEqual(packet, convertedPacket);
        }

        [Test]
        public void TestIPConverterFromObjectToBytes() {
            IPPacket packet = new IPPacket();
            packet.SrcMAC =
               new PhysicalAddress(new byte[] { 0x11, 0x22, 0x33, 0x44, 0x55, 0x66 });
            packet.DstMAC =
                new PhysicalAddress(new byte[] { 0x66, 0x55, 0x44, 0x33, 0x22, 0x11 });
            packet.SrcIP = new NetworkAddress("127.0.0.1");
            packet.DstIP = new NetworkAddress("1.1.1.1");

            byte[] binPacket = new byte[IPPacket.Size];
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

            IPPacketConverter converter = new IPPacketConverter();
            byte[] convertedBinPacket = converter.ConvertPacket(packet);
            Assert.AreEqual(convertedBinPacket, binPacket);
        }

    }
}
