using System.Diagnostics;

namespace Network.Safety
{
    class FilterCommand : FirewallCommand
    {
        public override NetworkPacket DoWithPacket(Firewall fw, NetworkPacket p) {
            if (p == null) {
                return null;
            }
            Debug.Assert(fw != null, "Firewall параметр равен null",
                "Нельзя получать объекты с значением null");
            IPPacket pack = p as IPPacket;
            if (fw.Filter.IPAddrsDst.Count != 0) {
                if (fw.Filter.IPAddrsDst.Contains(pack.DstIP)) {
                    return null;
                }
            }
            if (fw.Filter.IPAddrsSrc.Count != 0) {
                if (fw.Filter.IPAddrsSrc.Contains(pack.SrcIP)) {
                    return null;
                }
            }
            if (p is ICMPPacket) {
                ICMPPacket packet = p as ICMPPacket;
                if (fw.Filter.Protocols.Contains("icmp")) {
                    return null;
                }
            }
            else if (p is TCPPacket) {
                TCPPacket packet = p as TCPPacket;
                if (fw.Filter.Protocols.Contains("tcp")) {
                    return null;
                }
                if (fw.Filter.PortsDst.Contains(packet.DstPort)) {
                    return null;
                }
            }
            else if (p is UDPPacket) {
                UDPPacket packet = p as UDPPacket;
                if (fw.Filter.Protocols.Contains("udp")) {
                    return null;
                }
                if (fw.Filter.PortsDst.Contains(packet.DstPort)) {
                    return null;
                }
            }
            else {
                if (fw.Filter.Protocols.Contains("ip")) {
                    return null;
                }
            }
            return p;
        }

        public override bool Equals(object obj) {
            FilterCommand other = obj as FilterCommand;
            return other != null;
        }
    }
}
