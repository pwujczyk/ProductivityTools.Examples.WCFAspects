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
    //public class RawBodyWriter : BodyWriter
    //{
    //    object content;
    //    public RawBodyWriter(object content)
    //        : base(true)
    //    {
    //        this.content = content;
    //    }

    //    protected override void OnWriteBodyContents(System.Xml.XmlDictionaryWriter writer)
    //    {
    //        var s=Newtonsoft.Json.JsonConvert.SerializeObject(content);

    //       // DataContractJsonSerializer serializer = new DataContractJsonSerializer(content.GetType());

    //      writer.WriteStartElement("Binary");
    //        // serializer.WriteObject(writer, content);
    //        // //WriteBase64(content, 0, content.Length);
    //        writer.WriteString(s);
    //       writer.WriteEndElement();
    //    }
    //}

    class MyRawWriter : BodyWriter
    {
        byte[] data;
        public MyRawWriter(byte[] data)
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
