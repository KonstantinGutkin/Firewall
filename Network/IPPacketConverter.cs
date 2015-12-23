using System;
using System.Diagnostics;

namespace Network
{
    class IPPacketConverter : PacketConverter
    {
        public override NetworkPacket ConvertPacket(byte[] binPacket) {
            Debug.Assert(binPacket != null, "byte[] параметр равен null",
               "Нельзя получать объекты с значением null");
            if (binPacket.Length < IPPacket.Size) {
                throw new InvalidSizePacketException("Недопустимый размер IP - пакета: " +
                    binPacket.Length);
            }
            IPPacket ipPack = new IPPacket();
            int pointer = 0;
            ipPack.SrcMAC = new PhysicalAddress(binPacket, pointer);
            pointer += PhysicalAddress.Length;
            ipPack.DstMAC = new PhysicalAddress(binPacket, pointer);
            pointer += PhysicalAddress.Length;
            ipPack.SrcIP = new NetworkAddress(binPacket, pointer);
            pointer += NetworkAddress.Length;
            ipPack.DstIP = new NetworkAddress(binPacket, pointer);
            return ipPack;
        }

        public override byte[] ConvertPacket(NetworkPacket packet) {
            Debug.Assert(packet != null, "NetworkPacket параметр равен null",
               "Нельзя получать объекты с значением null");
            IPPacket ipPack = packet as IPPacket;
            if (ipPack == null) {
                throw new ConvertPacketException("Передан не IP-пакет");
            }
            byte[] binPacket = new byte[IPPacket.Size];
            int pointer = 0;
            Array.Copy(ipPack.SrcMAC.BytesOfAddr, 0, binPacket, pointer,
                PhysicalAddress.Length);
            pointer += PhysicalAddress.Length;
            Array.Copy(ipPack.DstMAC.BytesOfAddr, 0, binPacket, pointer,
                PhysicalAddress.Length);
            pointer += PhysicalAddress.Length;
            Array.Copy(ipPack.SrcIP.BytesOfAddr, 0, binPacket, pointer,
                NetworkAddress.Length);
            pointer += NetworkAddress.Length;
            Array.Copy(ipPack.DstIP.BytesOfAddr, 0, binPacket, pointer,
                NetworkAddress.Length);
            return binPacket;
        }
    }
}
