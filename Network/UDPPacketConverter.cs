using System;
using System.Diagnostics;
namespace lab4.Network
{
    public class UDPPacketConverter : IPPacketConverter
    {
        public override NetworkPacket ConvertPacket(byte[] binPacket) {
            Debug.Assert(binPacket != null, "byte[] параметр равен null",
               "Нельзя получать объекты с значением null");
            if (binPacket.Length < UDPPacket.Size) {
                throw new InvalidSizePacketException("Недопустимый размер UDP - пакета: " +
                    binPacket.Length);
            }
            UDPPacket udpPacket = new UDPPacket();
            IPPacket ipPacket = (IPPacket) base.ConvertPacket(binPacket);
            ipPacket.Copy(udpPacket);
            int pointer = IPPacket.Size;
            udpPacket.SrcPort = BitConverter.ToUInt16(binPacket, pointer);
            pointer += sizeof(short); //sizeof(SrcPort) = 2
            udpPacket.DstPort = BitConverter.ToUInt16(binPacket, pointer);
            pointer += sizeof(short);  //sizeof(DstPort) = 2
            Array.Copy(binPacket, pointer, udpPacket.Data, 0, udpPacket.Data.Length);
            return udpPacket;
        }

        public override byte[] ConvertPacket(NetworkPacket packet) {
            Debug.Assert(packet != null, "NetworkPacket параметр равен null",
               "Нельзя получать объекты с значением null");
            UDPPacket udpPacket = packet as UDPPacket;
            if (udpPacket == null) {
                throw new ConvertPacketException("Передан не UDP-пакет");
            }
            IPPacket ipPacket = packet as IPPacket;
            byte[] binPacket = new byte[packet.Length];
            Array.Copy(base.ConvertPacket(packet), 0, binPacket, 0, IPPacket.Size);
            int pointer = IPPacket.Size;
            Array.Copy(BitConverter.GetBytes(udpPacket.SrcPort), 0, binPacket,
                pointer, sizeof(short));
            pointer += sizeof(short);
            Array.Copy(BitConverter.GetBytes(udpPacket.DstPort), 0, binPacket,
                pointer, sizeof(short));
            pointer += sizeof(short);
            Array.Copy(udpPacket.Data, 0, binPacket, pointer, udpPacket.Data.Length);
            return binPacket;
        }
    }    
}
