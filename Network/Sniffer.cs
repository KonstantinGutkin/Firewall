using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.Network
{
    public abstract class Sniffer
    {
        public abstract NetworkPacket ConstructPacket(PacketConverter converter,
            byte[] binPacket);

        public abstract byte[] ConstructPacket(PacketConverter converter,
            NetworkPacket packet);
    }
}
