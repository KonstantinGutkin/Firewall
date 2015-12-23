using System.Diagnostics;

namespace Network.Safety
{
    class NATCommand : FirewallCommand
    {
        public override NetworkPacket DoWithPacket(Firewall fw, NetworkPacket p) {
            if (p == null) {
                return null;
            }
            Debug.Assert(fw != null, "Firewall параметр равен null",
                "Нельзя получать объекты с значением null");
            IPPacket packet = p as IPPacket;
            foreach (NetworkAddress[] addrs in fw.TableNAT) {
                if (addrs[0] == packet.SrcIP) {
                    packet.SrcIP = new NetworkAddress(addrs[1]);
                    return p;
                }
                if (addrs[1] == packet.DstIP) {
                    packet.DstIP = new NetworkAddress(addrs[0]);
                    return p;
                }
            }
            return p;
        }

        public override bool Equals(object obj) {
            NATCommand other = obj as NATCommand;
            return other != null;
        }
    }
}
