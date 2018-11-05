namespace FirewallTests
{
    using lab4.Network.Safety;
    using System.Collections.Generic;
    using lab4.Network;
    class FilterMock : Filter
    {
        public override void AddFilter(string filter) { }
        public override void ClearFilter() { }
        public override void DelFilter(string filter) { }
        public FilterMock() {
            IPAddrsSrc = new List<NetworkAddress>();
            IPAddrsDst = new List<NetworkAddress>();
            Protocols = new List<string>();
            PortsDst = new List<ushort>();
        }
    }
}
