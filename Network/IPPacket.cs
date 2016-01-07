using System.Diagnostics;

namespace lab4.Network
{
    public class IPPacket : NetworkPacket
    {
        public NetworkAddress SrcIP { get; set; }
        public NetworkAddress DstIP { get; set; }

        new public static int Size = NetworkPacket.Size + 2 * NetworkAddress.Length;

        public override int Length {
            get { return Size; }
        }

        public override void Copy(NetworkPacket dst) {
            base.Copy(dst);
            IPPacket ip = dst as IPPacket;
            ip.SrcIP = new NetworkAddress(this.SrcIP);
            ip.DstIP = new NetworkAddress(this.DstIP);
        }

        public override string ToString() {
            return "[IP]: source MAC = " + SrcMAC.ToString() + ", destination MAC = " +
                DstMAC.ToString() + ", source IP = " + SrcIP.ToString() +
                ", destination IP = " + DstIP.ToString();
        }
    }
}
