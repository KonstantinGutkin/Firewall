using NUnit.Framework;

namespace FirewallTests
{
    using lab4.Network.Safety;
    using lab4.Network;
    [TestFixture]
    class FirewallTest
    {
        Firewall fw;
        NetworkAddress srcIP, dstIP;
        [TestFixtureSetUp]
        public void SetUp() {
            fw = new Firewall(new FilterMock(), new DistributorMock());
            srcIP = new NetworkAddress("192.168.0.1");
            dstIP = new NetworkAddress("1.0.0.1");
        }
        [Test]
        public void TestAddAddrsToTableNat() {            
            fw.AddAddrsToTableNAT(srcIP, dstIP);
            Assert.AreEqual(fw.TableNAT[0][0], srcIP);
            Assert.AreEqual(fw.TableNAT[0][1], dstIP);
        }
        [Test]
        public void TestDelAddrsFromTableNat() {
            NetworkAddress srcIP1, srcIP2, dstIP1, dstIP2;
            fw.AddAddrsToTableNAT(srcIP, dstIP);
            srcIP1 = new NetworkAddress("192.168.0.2");
            dstIP1 = new NetworkAddress("1.0.0.2");
            srcIP2 = new NetworkAddress("192.168.0.3");
            dstIP2 = new NetworkAddress("1.0.0.3");
            fw.AddAddrsToTableNAT(srcIP1, dstIP1);
            fw.AddAddrsToTableNAT(srcIP2, dstIP2);
            Assert.AreEqual(fw.TableNAT.Count, 3);

            fw.DelAddrsFromTableNat(srcIP1, dstIP1);
            NetworkAddress[] record = new NetworkAddress[2];
            record[0] = srcIP1;
            record[1] = dstIP1;
            Assert.AreEqual(fw.TableNAT.Count, 2);
            Assert.AreNotEqual(fw.TableNAT[1][0], srcIP1);
            Assert.AreNotEqual(fw.TableNAT[1][1], dstIP1);
        }
    }
}
