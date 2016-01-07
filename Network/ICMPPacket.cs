using System;
using System.Diagnostics;

namespace lab4.Network
{
    public class ICMPPacket : IPPacket
    {
        public static int SizeData = 10;
        new public static int Size = IPPacket.Size + 2 * sizeof(byte) + SizeData;

        public byte Type { get; set; }
        public byte Code { get; set; }
        public byte[] Data { get; set; } = new byte[SizeData];

        public override int Length {
            get { return Size; }
        }
        public override void Copy(NetworkPacket dst) {
            base.Copy(dst);
            ICMPPacket icmp = dst as ICMPPacket;
            Type = icmp.Type;
            Code = icmp.Code;
            Array.Copy(icmp.Data, Data, icmp.Data.Length);
        }

        public override string ToString() {
            string result = base.ToString().Replace("[IP]", "[ICMP]");
            result += String.Format(", type = {0}, code = {1}, data = {2}", Type, Code,
                BitConverter.ToString(Data, 0));
            return result;
        }
    }
}
