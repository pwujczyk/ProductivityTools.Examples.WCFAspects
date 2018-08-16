using System;
using System.Runtime.Serialization;

namespace ProductivityTools.Examples.WCFAspects.Contract
{
    [Serializable]
    internal class OnlyNetTcpException : Exception
    {
        public OnlyNetTcpException()
        {
        }

        public OnlyNetTcpException(string message) : base(message)
        {
        }

        public OnlyNetTcpException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OnlyNetTcpException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}