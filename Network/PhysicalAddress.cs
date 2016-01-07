using System;
using System.Diagnostics;

namespace lab4.Network
{
    public class PhysicalAddress
    {
        byte[] _addr;
        public static int Length = 6;

        public PhysicalAddress(byte[] addr) {
            addr = new byte[6];
            Array.Copy(addr, this._addr, 6);
        }

        public PhysicalAddress(PhysicalAddress pa) {
            Debug.Assert(pa != null, "PhysicalAddress параметр равен null",
               "Нельзя получать объекты с значением null");
            _addr = new byte[6];
            Array.Copy(pa.BytesOfAddr, this._addr, 6);
        }

        public PhysicalAddress(byte[] addr, int startIndex) {
            Debug.Assert(addr != null, "byte[] параметр равен null",
               "Нельзя получать объекты с значением null");
            if (startIndex > addr.Length - 4) {
                throw new IndexOutOfRangeException();
            }
            this._addr = new byte[6];
            Array.Copy(addr, startIndex, this._addr, 0, 6);
        }

        public byte[] BytesOfAddr {
            get { return _addr; }
        }

        public override bool Equals(object obj) {
            PhysicalAddress otherAddr = obj as PhysicalAddress;
            if (otherAddr != null) {
                for (int i = 0; i < _addr.Length; i++) {
                    if (_addr[i] != otherAddr.BytesOfAddr[i])
                        return false;
                }
                return true;
            }
            else {
                return false;
            }
        }

        public override string ToString() {
            string result = "";
            for (int i = 0; i < _addr.Length; i++) {
                result += String.Format("{0:X2}:", _addr[i]);
            }
            return result.TrimEnd(':');
        }
    }
}
