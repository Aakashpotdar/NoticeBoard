using System;
using Model.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model.Exceptions
{
    public class ServerException : Exception
    {
        public ServerException(string message) : base(message) { }

        public ServerException(string message, Exception innerException):base(message, innerException) { }

        public ServerException(int errorCode,string message) : base() { }
    }
}
