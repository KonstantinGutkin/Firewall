using System.Diagnostics;
using System.ComponentModel;

namespace Network.Safety
{
    public abstract class DistributorOfFirewall
    {
        public abstract void Distribut(NetworkPacket packet);
    }

    class DistributorToBindingList : DistributorOfFirewall
    {
        BindingList<string> _location;

        public DistributorToBindingList(BindingList<string> location) {
            Debug.Assert(location != null, "ListBox параметр равен null",
                "Нельзя получать объекты с значением null");
            this._location = location;
        }

        public override void Distribut(NetworkPacket packet) {
            if (packet == null) {
                _location.Add("");
            }
            else {
                _location.Add(packet.ToString());
            }
        }
    }
}
