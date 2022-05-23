using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace HostDropBoxClone
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(WCFDropBoxClone.Service)))
            {
                host.Open();
                Console.WriteLine("host is started");
                Console.ReadLine();
            }
        }
    }
}
