using System;

namespace Network.Safety
{
    class InvalidFilterException : Exception
    {
        public InvalidFilterException() : base() { }

        public InvalidFilterException(string message) : base(message) { }
    }
}
