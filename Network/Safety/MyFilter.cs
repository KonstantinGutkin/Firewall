using System;
using System.Collections.Generic;

namespace lab4.Network.Safety
{
    public class MyFilter : Filter
    {
        public MyFilter() {
            IPAddrsSrc = new List<NetworkAddress>();
            IPAddrsDst = new List<NetworkAddress>();
            Protocols = new List<string>();
            PortsDst = new List<ushort>();
        }

        public override void AddFilter(string filter) {
            ///Разбирает строку filter и заносит значение в свои поля.
            ///Допустимые команды: ip.src = <ip-адрес> , ip.dst = <ip-aдрес>,
            ///port = <порт>, proto = <имя_протокола>
            ///при наличии нескольких команд, разделяйте точкой с запятой            
            if (filter == "") {
                return;
            }
            string[] cmds = filter.Replace(" ", "").ToLower().Split(';');
            foreach (string cmd in cmds) {
                if (cmd.Contains("ip.src")) {
                    IPAddrsSrc.Add(new NetworkAddress(cmd.Substring("ip.src=".Length)));
                }
                else if (cmd.Contains("ip.dst")) {
                    IPAddrsDst.Add(new NetworkAddress(cmd.Substring("ip.dst=".Length)));
                }
                else if (cmd.Contains("port")) {
                    PortsDst.Add(Convert.ToUInt16(cmd.Substring("port=".Length)));
                }
                else if (cmd.Contains("proto")) {
                    Protocols.Add(cmd.Substring("proto=".Length));
                }
                else {
                    throw new InvalidFilterException("Недопустимый фильтр: " + cmd);
                }
            }
        }

        public override void DelFilter(string filter) {
            //Разбирает строку filter и удаляет значения из своих полей.
            //Допустимые команды: ip.src = <ip-адрес> , ip.dst = <ip-aдрес>,
            //port = <порт>, proto = <имя_протокола>
            //при наличии нескольких команд, разделяйте точкой с запятой
            if (filter == "") {
                return;
            }
            string[] cmds = filter.Replace(" ", "").ToLower().Split(';');
            foreach (string cmd in cmds) {
                if (cmd.Contains("ip.src")) {
                    IPAddrsSrc.Remove(new NetworkAddress(cmd.Substring("ip.src=".Length)));
                }
                else if (cmd.Contains("ip.dst")) {
                    IPAddrsDst.Remove(new NetworkAddress(cmd.Substring("ip.dst=".Length)));
                }
                else if (cmd.Contains("port")) {
                    PortsDst.Remove(Convert.ToUInt16(cmd.Substring("port=".Length)));
                }
                else if (cmd.Contains("proto")) {
                    Protocols.Remove(cmd.Substring("proto=".Length));
                }
                else {
                    throw new InvalidFilterException("Недопустимый фильтр: " + cmd);
                }
            }
        }

        public override void ClearFilter() {
            IPAddrsSrc.Clear();
            IPAddrsDst.Clear();
            Protocols.Clear();
            PortsDst.Clear();
        }
    }
}
