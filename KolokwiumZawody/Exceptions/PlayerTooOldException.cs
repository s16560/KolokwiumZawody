using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace KolokwiumZawody.Exceptions
{
    public class PlayerTooOldException : Exception
    {
        public PlayerTooOldException()
        {
        }

        public PlayerTooOldException(string message) : base(message)
        {
        }

        public PlayerTooOldException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PlayerTooOldException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
