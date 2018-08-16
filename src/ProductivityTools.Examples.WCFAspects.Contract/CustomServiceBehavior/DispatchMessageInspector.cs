using ProductivityTools.ExamplesWcfAspects.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityTools.Examples.WCFAspects.Contract
{
    public class DispatchMessageInspector : IDispatchMessageInspector
    {
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            if (channel is IServiceChannel serviceChannel)
            {
                if (serviceChannel.ListenUri.Scheme == "net.tcp")
                {
                    string methodName=request.Headers.Action.Split('/').Last();
                    TypeInfo serviceType = instanceContext.Host.Description.ServiceType as TypeInfo;
                    foreach (var @interface in serviceType.ImplementedInterfaces)
                    {
                        var method = @interface.GetMethod(methodName);
                        if (method != null)
                        {
                            var attributes = method.GetCustomAttributes().Where(x => x.GetType() == typeof(WcfAllowedAttribute)).FirstOrDefault();
                            if (attributes == null)
                            {
                                throw new OnyWebApiException($"Method which was invoked: {methodName}");
                            }
                        }
                    }
                }
            }
            return request;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
           // throw new NotImplementedException();
        }
    }
}
