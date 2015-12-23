using System;
using System.Diagnostics;

namespace Network
{
    class IcmpPacketConverter : IPPacketConverter
    {
        public override NetworkPacket ConvertPacket(byte[] binPacket) {
            Debug.Assert(binPacket != null, "byte[] параметр равен null",
               "Нельзя получать объекты с значением null");
            if (binPacket.Length < ICMPPacket.Size) {
                throw new InvalidSizePacketException("Недопустимый размер ICMP - пакета: " +
                    binPacket.Length);
            }
            ICMPPacket icmpPacket = new ICMPPacket();
            IPPacket ipPacket = (IPPacket) base.ConvertPacket(binPacket);
            ipPacket.Copy(icmpPacket);
            int pointer = IPPacket.Size;
            icmpPacket.Type = binPacket[pointer++];
            icmpPacket.Code = binPacket[pointer++];
            Array.Copy(binPacket, pointer, icmpPacket.Data, 0, icmpPacket.Data.Length);
            return icmpPacket;
        }

        public override byte[] ConvertPacket(NetworkPacket packet) {
            Debug.Assert(packet != null, "NetworkPacket параметр равен null",
               "Нельзя получать объекты с значением null");
            ICMPPacket icmpPacket = packet as ICMPPacket;
            if (icmpPacket == null) {
                throw new ConvertPacketException("Передан не ICMP-пакет");
            }
            IPPacket ipPacket = packet as IPPacket;
            byte[] binPacket = new byte[ICMPPacket.Size];
            Array.Copy(base.ConvertPacket(packet), 0, binPacket, 0, IPPacket.Size);
            int pointer = IPPacket.Size;
            binPacket[pointer++] = icmpPacket.Type;
            binPacket[pointer++] = icmpPacket.Code;
            Array.Copy(icmpPacket.Data, 0, binPacket, pointer, icmpPacket.Data.Length);
            return binPacket;
        }
    }
}
