using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Exceptions.Exceptions
{
    public class ConflictException : Exception
    {
        public ConflictException(string message) : base(message)
        {

        }

    }
}
