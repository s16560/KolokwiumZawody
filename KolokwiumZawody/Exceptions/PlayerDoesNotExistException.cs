using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace KolokwiumZawody.Exceptions
{
    public class PlayerDoesNotExistException : Exception
    {
        public PlayerDoesNotExistException()
        {
        }

        public PlayerDoesNotExistException(string message) : base(message)
        {
        }

        public PlayerDoesNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PlayerDoesNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
