using System;
using System.Collections.Generic;
using System.Text;

namespace FTPapp.Exceptions
{
    public class UnknownCommandException : Exception
    {
        public UnknownCommandException(String message) : base (message)
        {
        }
    }
}
