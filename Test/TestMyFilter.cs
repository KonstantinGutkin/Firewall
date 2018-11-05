using NUnit.Framework;

namespace FirewallTests
{
    using lab4.Network.Safety;
    using lab4.Network;
    [TestFixture]
    class TestMyFilter
    {
        MyFilter filter;

        [TestFixtureSetUp]
        public void SetUp() {
            filter = new MyFilter();
        }

        [Test]
        public void TestSetFilterByCorrectFilterString() {
            string filt = "ip.src = 192.168.0.1; ip.dst = 1.2.3.4; port = 1;" +
                "proto = tcp";            
            filter.AddFilter(filt);
            Assert.Contains(new NetworkAddress("192.168.0.1"), filter.IPAddrsSrc);
            Assert.Contains(new NetworkAddress("1.2.3.4"), filter.IPAddrsDst);
            Assert.Contains(1, filter.PortsDst);
            Assert.Contains("tcp", filter.Protocols); 
        }

        [Test]
        public void TestSetFilterByIncorrectString() {
            string filt = "srcIP = 192.168.0.1; dstIP = 1.2.3.4; port = 1;" +
                "protocol = tcp";
            Assert.Throws<InvalidFilterException>(
                delegate { filter.AddFilter(filt); });
        }
    }
}
