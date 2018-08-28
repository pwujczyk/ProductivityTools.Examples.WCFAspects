﻿using System;
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
    public class ResponseJsonFormatter : IDispatchMessageFormatter
    {
        OperationDescription Operation;
        public ResponseJsonFormatter(OperationDescription operation)
        {
            this.Operation = operation;
        }

        public void DeserializeRequest(Message message, object[] parameters)
        {
        }

        public Message SerializeReply(MessageVersion messageVersion, object[] parameters, object result)
        {
            string json=Newtonsoft.Json.JsonConvert.SerializeObject(result);
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            Message replyMessage = Message.CreateMessage(messageVersion, Operation.Messages[1].Action, new RawDataWriter(bytes));
            replyMessage.Properties.Add(WebBodyFormatMessageProperty.Name, new WebBodyFormatMessageProperty(WebContentFormat.Raw));
            return replyMessage;
        }
    }
}