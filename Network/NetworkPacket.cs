using System.Diagnostics;

namespace lab4.Network
{
    public abstract class NetworkPacket
    {
        public PhysicalAddress SrcMAC { get; set; }
        public PhysicalAddress DstMAC { get; set; }

        public virtual void Copy(NetworkPacket dst) {
            Debug.Assert(dst != null, "NetworkPacket параметр равен null",
               "Нельзя получать объекты с значением null");
            dst.SrcMAC = new PhysicalAddress(SrcMAC);
            dst.DstMAC = new PhysicalAddress(DstMAC);
        }

        public static int Size = 2 * PhysicalAddress.Length;

        public virtual int Length {
            get { return Size; }
        }
    }
}
