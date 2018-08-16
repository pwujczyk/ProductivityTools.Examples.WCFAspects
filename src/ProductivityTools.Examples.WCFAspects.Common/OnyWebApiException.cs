using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityTools.ExamplesWcfAspects.Common
{
    public class OnyWebApiException : Exception
    {
        public OnyWebApiException()
        {
        }

        public OnyWebApiException(string message) : base(message)
        {
        }

        public OnyWebApiException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OnyWebApiException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
