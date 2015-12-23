using System.Diagnostics;
using System.Collections.Generic;

namespace Network.Safety
{
    public abstract class Filter
    {
        public List<NetworkAddress> IPAddrsSrc { get; protected set; }
        public List<NetworkAddress> IPAddrsDst { get; protected set; }
        public List<string> Protocols { get; protected set; }
        public List<ushort> PortsDst { get; protected set; }

        public abstract void AddFilter(string filter);

        public abstract void DelFilter(string filter);

        public abstract void ClearFilter();
    }
}
