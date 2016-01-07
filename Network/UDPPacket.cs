using System;
using System.Diagnostics;

namespace lab4.Network
{
    public class UDPPacket : IPPacket
    {
        public static int SizeData = 12;
        new public static int Size = IPPacket.Size + 2 * sizeof(ushort) + SizeData;

        public ushort SrcPort { get; set; }
        public ushort DstPort { get; set; }
        public byte[] Data { get; set; } = new byte[12];
        public override int Length {
            get { return Size; }
        }
        public override void Copy(NetworkPacket dst) {
            base.Copy(dst);
            UDPPacket udp = dst as UDPPacket;
            SrcPort = udp.SrcPort;
            DstPort = udp.DstPort;
            Array.Copy(udp.Data, Data, udp.Data.Length);
        }

        public override string ToString() {
            return "[UDP]: source MAC = " + SrcMAC.ToString() + ", destination MAC = " +
                DstMAC.ToString() + ", source IP = " + SrcIP.ToString() + ":" + SrcPort +
                ", destination IP = " + DstIP.ToString() + ":" + DstPort + ", data = " + BitConverter.ToString(Data);
        }
    }
}
