using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAndPlay
{
    public class RootObject
    {
        public string odataMetadata { get; set; }
        public List<Value> value { get; set; }
    }
}
