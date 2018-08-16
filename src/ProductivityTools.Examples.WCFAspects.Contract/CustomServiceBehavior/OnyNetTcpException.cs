using System;
using System.Runtime.Serialization;

namespace ProductivityTools.Examples.WCFAspects.Contract
{
    [Serializable]
    internal class OnyNetTcpException : Exception
    {
        public OnyNetTcpException()
        {
        }

        public OnyNetTcpException(string message) : base(message)
        {
        }

        public OnyNetTcpException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OnyNetTcpException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}