using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Publish_Subscribe.Pattern.Test
{
    [TestClass]
    public class PatternTest
    {
         List<Mock<IInvestor>> _investors;
         IBM _ibm;
        private int _notifiedInvestors;
        [TestInitialize]
        public void Initialize()
        {
            _ibm = new IBM(120.00);
            _investors = new List<Mock<IInvestor>>();
            _notifiedInvestors = 0;
            for (var i = 0; i < 3; i++)
            {
                var investor = new Mock<IInvestor>();
                investor.Setup(c => c.Update(_ibm)).Callback(() =>
                {
                    _notifiedInvestors++;
                });
                _investors.Add(investor);
            }
        }
        [TestMethod]
        public void When_Attach_investors_Shoud_Notify_AllOfthem_Change_Price()
        {   
            foreach (var investor in _investors)
            {
                _ibm.Attach(investor.Object);
            }
            Assert.AreEqual(0, _notifiedInvestors);
            _ibm.Price = 120.10;
            Assert.AreEqual(3, _notifiedInvestors);

        }
        [TestMethod]
        public void When_Detach_One_investor_Shoud_Notify_TheRest_When_Change_Price()
        {
            foreach (var investor in _investors)
            {
                _ibm.Attach(investor.Object);
            }
            Assert.AreEqual(0, _notifiedInvestors);
            _ibm.Price = 122;
            Assert.AreEqual(3, _notifiedInvestors);
            _notifiedInvestors = 0;
            _ibm.Detach(_investors.First().Object);
            _ibm.Price = 121;
            Assert.AreEqual(2, _notifiedInvestors);

        }
        [TestMethod]
        public void When_Detach_One_investor_And_Attach_Another_Shoud_Notify_TheRest_When_Change_Price()
        {            
            foreach (var investor in _investors)
            {
                _ibm.Attach(investor.Object);
            }
            Assert.AreEqual(0, _notifiedInvestors);
            _ibm.Price = 123;
            Assert.AreEqual(3, _notifiedInvestors);
            _notifiedInvestors = 0;
            _ibm.Detach(_investors.First().Object);
            _ibm.Price = 124;
            Assert.AreEqual(2, _notifiedInvestors);
            _notifiedInvestors = 0;
            _ibm.Attach(_investors.First().Object);
            _ibm.Price = 125;
            Assert.AreEqual(3, _notifiedInvestors);

        }
    }
}
