using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestAndPlay
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DpxFaultInjectionTenantConfigurer d = new DpxFaultInjectionTenantConfigurer();
            //d.CreateGroups().Wait();
            //d.PrintGroups().Wait();
            //d.CreateGroupAndPrintId().Wait();
            d.CreateGroupAndAddAsMember().Wait();

            int i = 1;
            string s = "hey{0}";
            String.Format(s, i);
            
            Console.Read();
        }
    }
}
