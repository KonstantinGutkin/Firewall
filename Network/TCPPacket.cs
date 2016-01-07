using System;
using System.Diagnostics;

namespace lab4.Network
{
    public class TCPPacket : IPPacket
    {
        public static int SizeData = 12;
        new public static int Size = IPPacket.Size + 2 * sizeof(ushort) + sizeof(uint) +
            SizeData;
        public ushort SrcPort { get; set; }
        public ushort DstPort { get; set; }
        public uint SeqNum { get; set; }
        public byte[] Data { get; set; } = new byte[12];
        public override int Length {
            get { return Size; }
        }
        public override void Copy(NetworkPacket dst) {
            base.Copy(dst);
            TCPPacket tcp = dst as TCPPacket;
            SrcPort = tcp.SrcPort;
            DstPort = tcp.DstPort;
            SeqNum = tcp.SeqNum;
            Array.Copy(tcp.Data, Data, tcp.Data.Length);
        }

        public override string ToString() {
            return "[TCP]: source MAC = " + SrcMAC.ToString() + ", destination MAC = " +
                DstMAC.ToString() + ", source IP = " + SrcIP.ToString() + ":" + SrcPort +
                ", destination IP = " + DstIP.ToString() + ":" + DstPort + ", seq = " +
                SeqNum + ", data = " + BitConverter.ToString(Data);
        }
    }
}
