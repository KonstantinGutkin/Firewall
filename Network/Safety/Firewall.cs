using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Network.Safety
{    
    public class Firewall
    {
        List<FirewallCommand> _functions;
        public Filter Filter { get; private set; }
        public Dictionary<string, int> Statistics { get; set; }
        public List<NetworkAddress[]> TableNAT { get; private set; }
        DistributorOfFirewall _distributor;

        public Firewall(Filter f, DistributorOfFirewall dbr) {
            Debug.Assert(f != null, "Filter параметр равен null",
                "Нельзя получать объекты с значением null");
            Debug.Assert(dbr != null, "DistributorOfFirewall параметр равен null",
                "Нельзя получать объекты с значением null");
            _functions = new List<FirewallCommand>();
            Filter = f;
            this._distributor = dbr;
            Statistics = new Dictionary<string, int>();
            Statistics.Add("ip", 0);
            Statistics.Add("icmp", 0);
            Statistics.Add("tcp", 0);
            Statistics.Add("udp", 0);
            Statistics.Add("total", 0);
            TableNAT = new List<NetworkAddress[]>();
        }

        public void AddFunction(FirewallCommand fc) {
            if (!_functions.Contains(fc)) {
                _functions.Add(fc);
            }
        }

        public void DelFunctions(FirewallCommand fc) {
            _functions.Remove(fc);
        }

        public void AddAddrsToTableNAT(NetworkAddress addrIn, NetworkAddress addrOut) {
            Debug.Assert(addrIn != null, "NetworkAddress параметр равен null",
                "Нельзя получать объекты с значением null");
            Debug.Assert(addrOut != null, "NetworkAddress параметр равен null",
                "Нельзя получать объекты с значением null");
            NetworkAddress[] record = new NetworkAddress[2];
            record[0] = new NetworkAddress(addrIn);
            record[1] = new NetworkAddress(addrOut);
            if (!TableNAT.Contains(record)) {
                TableNAT.Add(record);
            }
        }

        public int DelAddrsFromTableNat(NetworkAddress addrIn, NetworkAddress addrOut) {
            if(addrIn == null || addrOut == null) {
                return -1;
            }
            NetworkAddress[] record = new NetworkAddress[2];
            int i = 0;
            record[0] = new NetworkAddress(addrIn);
            record[1] = new NetworkAddress(addrOut);
            for (i = 0; i < TableNAT.Count; i++) {
                if (TableNAT[i][0] == record[0]) {
                    if (TableNAT[i][1] == record[1]) {
                        break;
                    }
                }
            }
            if (i != TableNAT.Count) {
                TableNAT.RemoveAt(i);
                return i;
            }
            return -1;
        }

        public void ClearTableNat() {
            TableNAT.Clear();
        }

        public delegate void MethodContainer(Dictionary<string, int> stat);

        public event MethodContainer OnUpdateStatistics; 

        public void Scan(NetworkPacket packet) {            
            foreach (FirewallCommand cmd in _functions) {
                packet = cmd.DoWithPacket(this, packet);
                if(packet == null) {
                    break;
                }
            }
            _distributor.Distribut(packet);
            if(_functions.Contains(new CollectStatCommand())) {
                OnUpdateStatistics(Statistics);
            }
        }
    }       
}
