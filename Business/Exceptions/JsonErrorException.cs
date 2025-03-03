using System;

namespace Business.Exceptions
{
    public class JsonErrorException : Exception
    {
        public JsonErrorException(string message = null) : base(message)
        {

        }
    }
}
