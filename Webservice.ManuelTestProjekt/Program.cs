using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webservice.Entities;
using Webservice.Servicelag;

namespace Webservice.ManuelTestProjekt
{
    class Program
    {
        static void Main(string[] args)
        {
            WebConnect web = new WebConnect();
            ExchangeRates r = web.GetExchangeRates();
            Console.WriteLine(r);
            Console.ReadKey();
        }
    }
}
