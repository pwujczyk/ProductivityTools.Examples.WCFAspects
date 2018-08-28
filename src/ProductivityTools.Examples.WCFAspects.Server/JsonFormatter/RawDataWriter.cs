using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProductivityTools.Examples.WCFAspects.Server.JsonFormatter
{
    class RawDataWriter : BodyWriter
    {
        byte[] data;
        public RawDataWriter(byte[] data)
            : base(true)
        {
            this.data = data;
        }

        protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
        {
            writer.WriteStartElement("Binary");
            writer.WriteBase64(data, 0, data.Length);
            writer.WriteEndElement();
        }
    }
}
