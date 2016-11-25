using System;
using System.Linq;

namespace Publish_Subscribe.Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
            var ibm = new IBM(36);
            var investors = string.Empty;
            while (string.IsNullOrWhiteSpace(investors)|| investors.Split(',').All(string.IsNullOrWhiteSpace))
            {
                Console.WriteLine("Please enter investors names comma(,) separated");
                investors = Console.ReadLine();   
            }          
                foreach (var name in investors.Split(',').Where(name => !string.IsNullOrWhiteSpace(name)))
                {
                    ibm.Attach(new Investor(name));
                }
            while (true)
            {
                Console.WriteLine("Please enter new price note that if the price new all investors will be notified");
                double price;
                if (double.TryParse(Console.ReadLine(), out price))
                {
                    ibm.Price = price;
                }
                else
                {
                    Console.WriteLine("Please enter valid price ");
                }
            }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
