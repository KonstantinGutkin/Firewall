﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.Network
{
    public class ParseNetworkAddressException : Exception
    {
        public ParseNetworkAddressException() : base() { }

        public ParseNetworkAddressException(string message) : base(message) { }
    }

    public class ConvertPacketException : Exception
    {
        public ConvertPacketException() : base() { }

        public ConvertPacketException(string message) : base(message) { }
    }

    public class InvalidSizePacketException : ConvertPacketException
    {
        public InvalidSizePacketException() : base() { }

        public InvalidSizePacketException(string message) : base(message) { }
    }
}
