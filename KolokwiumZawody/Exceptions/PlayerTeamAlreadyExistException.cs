using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace KolokwiumZawody.Exceptions
{
    public class PlayerTeamAlreadyExistException : Exception
    {
        public PlayerTeamAlreadyExistException()
        {
        }

        public PlayerTeamAlreadyExistException(string message) : base(message)
        {
        }

        public PlayerTeamAlreadyExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PlayerTeamAlreadyExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
