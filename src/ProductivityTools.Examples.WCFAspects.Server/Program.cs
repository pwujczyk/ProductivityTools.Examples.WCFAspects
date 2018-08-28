using ProductivityTools.Examples.WCFAspects.Contract;
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
            host.AddServiceEndpoint(typeof(ICustomContract), new WebHttpBinding(), Consts.WebHttpAddress);

            foreach (var endpoint in host.Description.Endpoints)
            {
                if (endpoint.Address.Uri.Scheme.StartsWith("http"))
                {
                    foreach (var operation in endpoint.Contract.Operations)
                    {
                        operation.OperationBehaviors.Add(new ClientJsonDateFormatter());
                    }
                    endpoint.Behaviors.Add(new WebHttpBehavior());
                }
            }

            host.Open();
            Console.WriteLine("Host opened. Hit button to shut it down.");
            Console.Read();
        }
    }
}
