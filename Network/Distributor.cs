using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;

namespace Network
{
    using PatternObserver;
    using HelperClasses;

    class Distributor : IObserver
    {
        TrafficGenerator _generator;
        BindingList<string> _location;
        public Distributor(TrafficGenerator tg, BindingList<string> location) {
            Debug.Assert(tg != null, "TrafficGenerator параметр равен null",
               "Нельзя получать объекты с значением null");
            Debug.Assert(location != null, "ListBox параметр равен null",
               "Нельзя получать объекты с значением null");
            _generator = tg;
            this._location = location;
        }

        public void UpdateState() {
            byte[] binPacket = _generator.GetState();
            VirtualTrafficsSniffer snif = new VirtualTrafficsSniffer(_generator);
            NetworkPacket packet = snif.GetPacket(binPacket);
            _location.Add(packet.ToString());
        }
    }
}
