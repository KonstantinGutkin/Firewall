using NUnit.Framework;
using System.Collections.Generic;
namespace FirewallTests
{
    using lab4.Network.Safety;
    using lab4.Network;
    using System;

    [TestFixture]
    class CollectStatCommandTest
    {
        [Test]
        public void CollectStatWhenGiven2ip2icmp1tcp5udpPacketsThenCountOfPacketsIsRight() {
            NetworkPacket[] packets = new NetworkPacket[10];
            packets[0] = new IPPacket();
            packets[1] = new IPPacket();
            packets[2] = new ICMPPacket();
            packets[3] = new ICMPPacket();
            packets[4] = new TCPPacket();
            packets[5] = new UDPPacket();
            packets[6] = new UDPPacket();
            packets[7] = new UDPPacket();
            packets[8] = new UDPPacket();
            packets[9] = new UDPPacket();
            Firewall fw = new Firewall(new FilterMock(),
                new DistributorMock());
            CollectStatCommand clltStat = new CollectStatCommand();
            Assert.AreEqual(fw.Statistics["ip"], 0);
            Assert.AreEqual(fw.Statistics["icmp"], 0);
            Assert.AreEqual(fw.Statistics["tcp"], 0);
            Assert.AreEqual(fw.Statistics["udp"], 0);
            Assert.AreEqual(fw.Statistics["total"], 0);
            foreach (var packet in packets) {
                clltStat.DoWithPacket(fw, packet);
            }
            Assert.AreEqual(fw.Statistics["ip"], 2);
            Assert.AreEqual(fw.Statistics["icmp"], 2);
            Assert.AreEqual(fw.Statistics["tcp"], 1);
            Assert.AreEqual(fw.Statistics["udp"], 5);
            Assert.AreEqual(fw.Statistics["total"], 10);
        }
    }
   
    
    //class Firewall
    //{
    //    public Dictionary<string, int> Statistics { get; set; }

    //    public Firewall() {
    //        Statistics = new Dictionary<string, int>();
    //        Statistics.Add("ip", 0);
    //        Statistics.Add("icmp", 0);
    //        Statistics.Add("tcp", 0);
    //        Statistics.Add("udp", 0);
    //        Statistics.Add("total", 0);
    //    }
    //}

    //class NetworkPacket { }

    //class IPPacket : NetworkPacket { }

    //class ICMPPacket : IPPacket { }

    //class TCPPacket : IPPacket { }

    //class UDPPacket : IPPacket { }
}
