using System.Diagnostics;

namespace lab4.Network
{
    using PatternObserver;
    using HelperClasses;

    public class VirtualTrafficsSniffer : Sniffer, IObserver
    {
        TrafficGenerator _generator;
        byte[] _binPacket;

        public VirtualTrafficsSniffer(TrafficGenerator tg) {
            Debug.Assert(tg != null, "TrafficGenerator параметр равен null",
               "Нельзя получать объекты с значением null");
            this._generator = tg;
        }

        public delegate void MethodContainer(NetworkPacket packet);

        public event MethodContainer OnPacket;

        public void UpdateState() {
            _binPacket = _generator.GetState();
            NetworkPacket packet = GetPacket(_binPacket);
            OnPacket(packet); //генерируем событие         
        }

        public NetworkPacket GetPacket(byte[] binPacket) {
            Debug.Assert(binPacket != null, "byte[] параметр равен null",
               "Нельзя получать объекты с значением null");
            NetworkPacket packet;
            try {
                if (binPacket.Length == IPPacket.Size) {
                    packet = ConstructPacket(new IPPacketConverter(), binPacket);
                }
                else if (binPacket.Length == TCPPacket.Size) {
                    packet = ConstructPacket(new TCPPacketConverter(), binPacket);
                }
                else if (binPacket.Length == UDPPacket.Size) {
                    packet = ConstructPacket(new UDPPacketConverter(), binPacket);
                }
                else if (binPacket.Length == ICMPPacket.Size) {
                    packet = ConstructPacket(new IcmpPacketConverter(), binPacket);
                }
                else {
                    throw new InvalidSizePacketException();
                }
            }
            catch (ConvertPacketException) {
                packet = null;
            }
            return packet;
        }

        public override NetworkPacket ConstructPacket(PacketConverter converter,
            byte[] binPacket) {
            Debug.Assert(converter != null, "PacketConverter параметр равен null",
               "Нельзя получать объекты с значением null");
            NetworkPacket res;
            try {
                res = converter.ConvertPacket(binPacket);
            }
            catch (ConvertPacketException) {
                res = null;
            }
            return res;
        }

        public override byte[] ConstructPacket(PacketConverter converter,
            NetworkPacket packet) {
            Debug.Assert(converter != null, "PacketConverter параметр равен null",
               "Нельзя получать объекты с значением null");
            byte[] res;
            try {
                res = converter.ConvertPacket(packet);
            }
            catch (ConvertPacketException) {
                res = null;
            }
            return res;
        }
    }
}
