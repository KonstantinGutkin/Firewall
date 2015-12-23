using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Network
{
    public class NetworkAddress : IComparer<NetworkAddress>
    {
        byte[] _addr;
        public static int Length = 4;

        public NetworkAddress(byte[] addr) {
            Debug.Assert(addr != null, "byte[] параметр равен null",
                "Нельзя получать объекты с значением null");
            addr = new byte[4];
            Array.Copy(addr, this._addr, 4);
        }

        public NetworkAddress(byte[] addr, int startIndex) {
            Debug.Assert(addr != null, "byte[] параметр равен null",
                "Нельзя получать объекты с значением null");
            if (startIndex > addr.Length - 4) {
                throw new IndexOutOfRangeException();
            }
            this._addr = new byte[4];
            Array.Copy(addr, startIndex, this._addr, 0, 4);
        }

        public NetworkAddress(NetworkAddress addr) {
            Debug.Assert(addr != null, "NetworkAddress параметр равен null",
                "Нельзя получать объекты с значением null");
            this._addr = new byte[4];
            Array.Copy(addr.BytesOfAddr, this._addr, 4);
        }

        public NetworkAddress(string addr) {
            this._addr = new byte[4];
            string[] bytes = addr.Split('.');
            if (bytes.Length != 4) {
                throw new ParseNetworkAddressException();
            }
            for (int i = 0; i < bytes.Length; i++) {
                if (!Byte.TryParse(bytes[i], out this._addr[i])) {
                    throw new ParseNetworkAddressException();
                }
            }
        }
        public byte[] BytesOfAddr {
            get { return _addr; }
        }

        public static bool operator ==(NetworkAddress a1, NetworkAddress a2) {
            return a1.Equals(a2);
        }
        public static bool operator !=(NetworkAddress a1, NetworkAddress a2) {
            return !a1.Equals(a2);
        }
        public override bool Equals(object obj) {
            return obj == null ? false : this.GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode() {
            int hash = 0;
            for (int i = 0; i < _addr.Length; i++) {
                hash <<= 8;
                hash |= _addr[i];
            }
            return hash;
        }

        public override string ToString() {
            string result = "";
            for (int i = 0; i < _addr.Length; i++) {
                result += String.Format("{0}.", _addr[i]);
            }
            return result.TrimEnd('.');
        }

        public int Compare(NetworkAddress a1, NetworkAddress a2) {
            for (int i = 0; i < 0; i++) {
                if (a1.BytesOfAddr[i] != a2.BytesOfAddr[i]) {
                    return a1.BytesOfAddr[i] - a2.BytesOfAddr[i];
                }
            }
            return 0;
        }
    }
}
