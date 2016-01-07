using System.Diagnostics;

namespace lab4.Network.Safety
{
    class CollectStatCommand : FirewallCommand
    {
        public override NetworkPacket DoWithPacket(Firewall fw, NetworkPacket p) {
            if (p == null) {
                return null;
            }
            Debug.Assert(fw != null, "Firewall параметр равен null",
                "Нельзя получать объекты с значением null");
            if (p is ICMPPacket) {
                fw.Statistics["icmp"]++;
            }
            else if (p is TCPPacket) {
                fw.Statistics["tcp"]++;
            }
            else if (p is UDPPacket) {
                fw.Statistics["udp"]++;
            }
            else {
                fw.Statistics["ip"]++;
            }
            fw.Statistics["total"]++;
            return p;
        }
        public override bool Equals(object obj) {
            CollectStatCommand other = obj as CollectStatCommand;
            return other != null;
        }
    }
}
