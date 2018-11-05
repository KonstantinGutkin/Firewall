namespace FirewallTests
{
    using lab4.Network.Safety;
    using lab4.Network;
    class DistributorMock : DistributorOfFirewall
    {
        public override void Distribut(NetworkPacket packet) { }
    }
}
