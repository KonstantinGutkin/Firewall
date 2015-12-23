using System;
using System.Diagnostics;

namespace HelperClasses
{
    using PatternObserver;
    using Network;

    class TrafficGenerator : Subject
    {
        NetworkAddress _subnet;
        NetworkAddress _mask;
        byte[] _binPacket;
        System.Windows.Forms.Timer _timer;

        public TrafficGenerator(uint intervalGeneration, NetworkAddress subnet,
            NetworkAddress mask) : base() {
            Debug.Assert(subnet != null, "NetworkkAddress параметр равен null",
               "Нельзя получать объекты с значением null");
            Debug.Assert(mask != null, "NetworkkAddress параметр равен null",
               "Нельзя получать объекты с значением null");
            if (intervalGeneration == 0) {
                intervalGeneration = 1000;
            }
            this._timer = new System.Windows.Forms.Timer();
            this._timer.Interval = (int) intervalGeneration;
            this._timer.Tick += new System.EventHandler(Timer_Tick);
            this._subnet = new NetworkAddress(subnet);
            this._mask = new NetworkAddress(mask);
            this._timer.Enabled = false;
        }

        public void Start() {
            this._timer.Enabled = true;
        }

        public void Pause() {
            this._timer.Enabled = false;
        }

        public byte[] GetState() {
            return _binPacket;
        }

        private void Timer_Tick(object sender, EventArgs e) {
            Random rnd = new Random();
            int[] packetsSize = { IPPacket.Size, ICMPPacket.Size, UDPPacket.Size,
                TCPPacket.Size};
            int typeProtocol = rnd.Next(4);
            _binPacket = GeneratePacket(packetsSize[typeProtocol], _subnet, _mask);
            //сообщаем всем наблюдателям, что появился сетевой пакет
            Notify();
        }

        private bool IsPossibleSizePacket(int packetLength) {
            return packetLength == IPPacket.Size || packetLength == TCPPacket.Size ||
                packetLength == UDPPacket.Size || packetLength == ICMPPacket.Size;
        }
        private byte[] GeneratePacket(int packetLength) {
            if (!IsPossibleSizePacket(packetLength)) {
                throw new InvalidSizePacketException("Для генерирования задан неверный размер пакета");
            }
            Random rnd = new Random();
            byte[] packet = new byte[packetLength];
            rnd.NextBytes(packet);
            return packet;
        }

        private byte[] GeneratePacket(int packetLength,
            NetworkAddress subnet, NetworkAddress mask) {
            if (!IsPossibleSizePacket(packetLength)) {
                throw new InvalidSizePacketException("Для генерирования задан неверный размер пакета");
            }
            Debug.Assert(subnet != null, "NetworkkAddress параметр равен null",
               "Нельзя получать объекты с значением null");
            Debug.Assert(mask != null, "NetworkkAddress параметр равен null",
               "Нельзя получать объекты с значением null");
            Random rnd = new Random();
            byte[] packet = new byte[packetLength];
            rnd.NextBytes(packet);
            for (int i = 0; i < NetworkAddress.Length; i++) {
                packet[NetworkPacket.Size + i] &= (byte) ~mask.BytesOfAddr[i];
                packet[NetworkPacket.Size + i] |= subnet.BytesOfAddr[i];
            }
            return packet;
        }
    }
}
