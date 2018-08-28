using ProductivityTools.Examples.WCFAspects.Server.JsonFormatter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityTools.Examples.WCFAspects.Server.JsonFormatter
{ 
    public class ClientJsonDateFormatter : IOperationBehavior
    {
        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {
            // throw new NotImplementedException();
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            dispatchOperation.Formatter = new ResponseJsonFormatter(operationDescription);
        }

        public void Validate(OperationDescription operationDescription)
        {
            // throw new NotImplementedException();
        }
    }
}
