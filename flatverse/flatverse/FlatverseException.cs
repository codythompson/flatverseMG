using System;

namespace flatverse
{
    public class FlatverseException : Exception
    {
        public FlatverseException(string message)
            : base(message)
        {

        }
    }
}