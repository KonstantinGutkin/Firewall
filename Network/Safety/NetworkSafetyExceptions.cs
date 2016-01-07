using System;

namespace lab4.Network.Safety
{
    public class InvalidFilterException : Exception
    {
        public InvalidFilterException() : base() { }

        public InvalidFilterException(string message) : base(message) { }
    }
}
