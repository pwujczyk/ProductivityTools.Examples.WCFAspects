using ProductivityTools.Examples.WCFAspects.Contract;
using ProductivityTools.Examples.WCFAspects.Server.ClientJsonDateFormatter;
using ProductivityTools.Examples.WCFAspects.Server.JsonFormatter;
using ProductivityTools.Examples.WCFAspects.Service;
using ProductivityTools.ExamplesWcfAspects.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityTools.Examples.WCFAspects.Server
{

    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host;
            host = new ServiceHost(typeof(CustomService));
            host.AddServiceEndpoint(typeof(ICustomContract), new NetTcpBinding(), Consts.NetTcpAddress);
            host.AddServiceEndpoint(typeof(ICustomContract), new WebHttpBinding(), Consts.WebHttpAddress);

            foreach (var endpoint in host.Description.Endpoints)
            {
                if (endpoint.Address.Uri.Scheme.StartsWith("http"))
                {
                    //endpoint.Behaviors.Add(new DateTimeJsonBehavior());
                    endpoint.Contract.Operations.Find("Method1").Behaviors.Add(new MyOperationBehavior());
                    var x = new WebHttpBehavior();
                    x.DefaultOutgoingRequestFormat = WebMessageFormat.Json;
                    endpoint.Behaviors.Add(x);
                }
            }

            host.Open();
            Console.WriteLine("Host opened. Hit button to shut it down");
            Console.Read();
        }
    }
}
