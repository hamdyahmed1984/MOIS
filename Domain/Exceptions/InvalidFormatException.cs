using System;

namespace Domain.Exceptions
{
    public class InvalidFormatException : Exception
    {
        internal InvalidFormatException(string businessMessage) : base(businessMessage) { }
    }
}
