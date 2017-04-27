using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Data.TestRepo;
using Models;
using Models.Interfaces;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    class TestOrderMgr
    {
        [Test]
        public void GetOrder()
        {
            IOrderRepo repo = new TestOrderRepo();
            DateTime date = new DateTime(2000, 11, 11);
            OrderMgr orderMgr = new OrderMgr(repo);
            List<Order> orders = orderMgr.GetOrders(date);
            Assert.IsNotNull(orders);
        }

        [Test]
        public void AddOrder()
        {
            IOrderRepo repo = new TestOrderRepo();
            DateTime date = new DateTime(2000, 11, 11);
            OrderMgr orderMgr = new OrderMgr(repo);
           
           Order order = new Order();
            List<Order> orders = orderMgr.GetOrders(date);
          orderMgr.AddOrder(order);
            Assert.AreEqual(order, orders.Last());
        }
    }
}
