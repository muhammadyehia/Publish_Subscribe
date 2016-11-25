using System;
using System.Collections.Generic;

namespace Publish_Subscribe.Pattern
{
  public  abstract class Stock
    {
        double _price;
        readonly List<IInvestor> _investors = new List<IInvestor>();

        protected Stock(string symbol, double price)
        {
            Symbol = symbol;
            _price = price;
        }

        public void Attach(IInvestor investor)
        {
            _investors.Add(investor);
        }

        public void Detach(IInvestor investor)
        {
            _investors.Remove(investor);
        }

        public void Notify()
        {
            foreach (var investor in _investors)
            {
                investor.Update(this);
            }

            Console.WriteLine("");
        }

       
        public double Price
        {
            get { return _price; }
            set
            {
                if (_price == value) return;
                _price = value;
                Notify();
            }
        }
        public string Symbol { get; }
    }
}
