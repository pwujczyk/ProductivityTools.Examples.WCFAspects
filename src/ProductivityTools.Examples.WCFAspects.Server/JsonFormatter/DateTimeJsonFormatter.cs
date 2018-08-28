using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityTools.Examples.WCFAspects.Server.JsonFormatter
{
    public class DateTimeJsonFormatter : IDispatchMessageFormatter
    {
        OperationDescription Operation;
        public DateTimeJsonFormatter(OperationDescription operation)
        {
            this.Operation = operation;
        }

        public void DeserializeRequest(Message message, object[] parameters)
        {


        }

        public Message SerializeReply(MessageVersion messageVersion, object[] parameters, object result)
        {
            //DateTime body;
            //body = DateTime.Now;
            string json=Newtonsoft.Json.JsonConvert.SerializeObject(result);
            //string json = JsonConvert.SerializeObject(serializable);
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            Message replyMessage = Message.CreateMessage(messageVersion, Operation.Messages[1].Action, new MyRawWriter(bytes));
            replyMessage.Properties.Add(WebBodyFormatMessageProperty.Name, new WebBodyFormatMessageProperty(WebContentFormat.Raw));
            //replyMessage.
            // replyMessage.Properties.Add(WebBodyFormatMessageProperty.Name, new WebBodyFormatMessageProperty(WebContentFormat.Json));

            //var responseMessageProperty = new HttpResponseMessageProperty
            //{
            //    StatusCode = System.Net.HttpStatusCode.OK
            //};
            //replyMessage.Properties.Add(HttpResponseMessageProperty.Name, responseMessageProperty);



            //WebGetAttribute webGetAttribute = Operation.Behaviors.Find<WebGetAttribute>();
            //webGetAttribute.ResponseFormat = WebMessageFormat.Json;
            //webGetAttribute.BodyStyle = WebMessageBodyStyle.Bare;
            //replyMessage.Properties.Add("fdsa", "fdsa");
            return replyMessage;
        }
    }
}
