using ProductivityTools.Examples.WCFAspects.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityTools.Examples.WCFAspects.Service
{
    public class CustomService : ICustomContract
    {
        public string Method1(string s)
        {
            return s;
        }

        public string Method2(string s)
        {
            return s;
        }
    }
}
