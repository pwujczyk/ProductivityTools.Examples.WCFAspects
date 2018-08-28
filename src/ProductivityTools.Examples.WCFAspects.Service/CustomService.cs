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
        public PlaceTime Method1()
        {
            return new PlaceTime { City = "Warsaw", DateTime = DateTime.Now };
        }
    }
}
