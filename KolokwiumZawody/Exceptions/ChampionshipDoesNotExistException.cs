using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace KolokwiumZawody.Exceptions
{
    public class ChampionshipDoesNotExistException : Exception
    {
        public ChampionshipDoesNotExistException()
        {
        }

        public ChampionshipDoesNotExistException(string message) : base(message)
        {
        }

        public ChampionshipDoesNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ChampionshipDoesNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
