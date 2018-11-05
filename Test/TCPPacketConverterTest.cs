using NUnit.Framework;

namespace FirewallTests
{
    using lab4.Network;
    [TestFixture]
    class TCPPacketConverterTest
    {
        [Test]
        public void TestTCPConverterFromBytesToObject() {
            byte[] binPacket = new byte[TCPPacket.Size];
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
            //Source port
            binPacket[20] = 0x11;
            binPacket[21] = 0x11;
            //Destination port
            binPacket[22] = 0x22;
            binPacket[23] = 0x22;
            //Sequence number
            binPacket[24] = 0x0;
            binPacket[25] = 0x0;
            binPacket[26] = 0x1;
            binPacket[27] = 0x1;
            //Data
            binPacket[28] = 1;
            binPacket[29] = 2;

            TCPPacket packet = new TCPPacket();
            packet.SrcMAC =
               new PhysicalAddress(new byte[] { 0x11, 0x22, 0x33, 0x44, 0x55, 0x66 });
            packet.DstMAC =
                new PhysicalAddress(new byte[] { 0x66, 0x55, 0x44, 0x33, 0x22, 0x11 });
            packet.SrcIP = new NetworkAddress("127.0.0.1");
            packet.DstIP = new NetworkAddress("1.1.1.1");
            packet.SrcPort = 0x1111;
            packet.DstPort = 0x2222;
            packet.SeqNum = 0x1010000;
            packet.Data[0] = 1;
            packet.Data[1] = 2;

            TCPPacketConverter converter = new TCPPacketConverter();
            TCPPacket convertedPacket = (TCPPacket) converter.ConvertPacket(binPacket);
            Assert.AreEqual(packet, convertedPacket);
        }

        [Test]
        public void TestIPConverterFromObjectToBytes() {
            byte[] binPacket = new byte[TCPPacket.Size];
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
            //Source port
            binPacket[20] = 0x11;
            binPacket[21] = 0x11;
            //Destination port
            binPacket[22] = 0x22;
            binPacket[23] = 0x22;
            //Sequence number
            binPacket[24] = 0x0;
            binPacket[25] = 0x0;
            binPacket[26] = 0x1;
            binPacket[27] = 0x1;
            //Data
            binPacket[28] = 1;
            binPacket[29] = 2;

            TCPPacket packet = new TCPPacket();
            packet.SrcMAC =
               new PhysicalAddress(new byte[] { 0x11, 0x22, 0x33, 0x44, 0x55, 0x66 });
            packet.DstMAC =
                new PhysicalAddress(new byte[] { 0x66, 0x55, 0x44, 0x33, 0x22, 0x11 });
            packet.SrcIP = new NetworkAddress("127.0.0.1");
            packet.DstIP = new NetworkAddress("1.1.1.1");
            packet.SrcPort = 0x1111;
            packet.DstPort = 0x2222;
            packet.SeqNum = 0x1010000;
            packet.Data[0] = 1;
            packet.Data[1] = 2;

            TCPPacketConverter converter = new TCPPacketConverter();
            byte[] convertedBinPacket = converter.ConvertPacket(packet);
            Assert.AreEqual(convertedBinPacket, binPacket);
        }
    }
}
