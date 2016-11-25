using System;

namespace Publish_Subscribe.Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var ibm = new IBM(120.00);
            ibm.Attach(new Investor("Muhammad"));
            ibm.Attach(new Investor("Yehia"));
            ibm.Attach(new Investor("Elsayed"));
            ibm.Price = 120.10;
            ibm.Price = 121.00;
            ibm.Price = 120.50;
            ibm.Price = 120.75;
            Console.ReadKey();
        }
    }
}
