using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityTools.Examples.WCFAspects.Contract
{
    [ServiceContract]
    public interface ICustomContract
    {
        [OperationContract]
        [WebGet]
        [WcfAllowed]
        string Method1(string s);

        [OperationContract]
        [WebGet]
        string Method2(string s);
    }
}
