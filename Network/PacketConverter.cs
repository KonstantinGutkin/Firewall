namespace Network
{
    abstract class PacketConverter
    {
        public abstract NetworkPacket ConvertPacket(byte[] binPacket);
        public abstract byte[] ConvertPacket(NetworkPacket packet);
    }
}
