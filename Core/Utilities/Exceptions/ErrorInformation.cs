using System;

namespace Core.Utilities.Exceptions
{
    public class ErrorInformation : Exception
    {
        public ErrorInformation(string message = null) : base(message)
        {

        }
    }
}
