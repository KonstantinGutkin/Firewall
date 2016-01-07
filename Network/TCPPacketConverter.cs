using System;
using System.Diagnostics;

namespace lab4.Network
{
    public class TCPPacketConverter : IPPacketConverter
    {
        public override NetworkPacket ConvertPacket(byte[] binPacket) {
            Debug.Assert(binPacket != null, "byte[] параметр равен null",
               "Нельзя получать объекты с значением null");
            if (binPacket.Length < TCPPacket.Size) {
                throw new InvalidSizePacketException("Недопустимый размер TCP - пакета: " +
                    binPacket.Length);
            }
            TCPPacket tcpPacket = new TCPPacket();
            IPPacket ipPacket = (IPPacket) base.ConvertPacket(binPacket);
            ipPacket.Copy(tcpPacket);
            int pointer = IPPacket.Size;
            tcpPacket.SrcPort = BitConverter.ToUInt16(binPacket, pointer);
            pointer += sizeof(ushort); //sizeof(SrcPort) = 2
            tcpPacket.DstPort = BitConverter.ToUInt16(binPacket, pointer);
            pointer += sizeof(ushort);  //sizeof(DstPort) = 2
            tcpPacket.SeqNum = BitConverter.ToUInt32(binPacket, pointer);
            pointer += sizeof(uint); //sizeof(DstPort) = 2
            Array.Copy(binPacket, pointer, tcpPacket.Data, 0, TCPPacket.SizeData);
            return tcpPacket;
        }

        public override byte[] ConvertPacket(NetworkPacket packet) {
            Debug.Assert(packet != null, "NetworkPacket параметр равен null",
               "Нельзя получать объекты с значением null");
            TCPPacket tcpPacket = packet as TCPPacket;
            if (tcpPacket == null) {
                throw new ConvertPacketException("Передан не TCP-пакет");
            }
            IPPacket ipPacket = packet as IPPacket;
            byte[] binPacket = new byte[packet.Length];
            Array.Copy(base.ConvertPacket(packet), 0, binPacket, 0, IPPacket.Size);
            int pointer = IPPacket.Size;
            Array.Copy(BitConverter.GetBytes(tcpPacket.SrcPort), 0, binPacket,
                pointer, sizeof(short));
            pointer += sizeof(short);
            Array.Copy(BitConverter.GetBytes(tcpPacket.DstPort), 0, binPacket,
                pointer, sizeof(short));
            pointer += sizeof(short);
            Array.Copy(BitConverter.GetBytes(tcpPacket.SeqNum), 0, binPacket,
                pointer, sizeof(int));
            pointer += sizeof(int);
            Array.Copy(tcpPacket.Data, 0, binPacket, pointer, tcpPacket.Data.Length);
            return binPacket;
        }
    }
}
