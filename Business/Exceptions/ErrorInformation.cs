using System;

namespace Business.Exceptions
{
    public class ErrorInformation : Exception
    {
        public ErrorInformation(string message = null) : base(message)
        {

        }
    }
}
