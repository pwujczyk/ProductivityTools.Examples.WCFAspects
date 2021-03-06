﻿using ProductivityTools.Examples.WCFAspects.Contract;
using ProductivityTools.ExamplesWcfAspects.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityTools.Examples.WCFAspects.Client
{
    class Program
    {

        static void Write (string s)
        {
            Console.WriteLine(s);
        }
        static void TryInvoke(Func<string> a)
        {
            try
            {
                Write(a());
            }
            catch (Exception ex)
            {
                Write(ex.Message);
                
            }
        }
        static void Main(string[] args)
        {
            ChannelFactory<ICustomContract> netTcpFactory = new ChannelFactory<ICustomContract>(new NetTcpBinding(), Consts.NetTcpAddress);
            netTcpFactory.Endpoint.Behaviors.Add(new CustomEndpointBehavior("client"));
            ICustomContract netTcpProxy = netTcpFactory.CreateChannel();
            TryInvoke(()=>netTcpProxy.Method1("Hello 1 - net tcp"));
            TryInvoke(() => netTcpProxy.Method2("Hello 2 - net tcp"));

            ChannelFactory<ICustomContract> webHttpFactory = new ChannelFactory<ICustomContract>(new WebHttpBinding(), Consts.WebHttpAddress);
            webHttpFactory.Endpoint.Behaviors.Add(new CustomEndpointBehavior("client"));
            webHttpFactory.Endpoint.Behaviors.Add(new WebHttpBehavior());
            ICustomContract webHttpProxy = webHttpFactory.CreateChannel();
            TryInvoke(() => webHttpProxy.Method1("Hello 1 - web http"));
            TryInvoke(() => webHttpProxy.Method2("Hello 2 - web http"));

            Console.ReadLine();

        }
    }
}
