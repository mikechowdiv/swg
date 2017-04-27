using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Data.TestRepo;
using Models;
using Models.Interfaces;
using Models.Responses;
using NUnit.Framework;
using Tests.Mocks;

namespace Tests
{
    [TestFixture]
    class ProdTest
    {
        [Test]
        public void GetProd()
        {
            IProdRepo repo = new TestProdRepo();
            ProductMgr pm = new ProductMgr(repo);
            ProductResponse resp = pm.GetProduct("wood");
            Product prod = resp.Product;
            Assert.IsNotNull(prod);
        }

        [Test]
        public void GetProdFail()
        {
            IProdRepo repo = new InvalidProd();
            ProductMgr pm = new ProductMgr(repo);
            ProductResponse resp = pm.GetProduct("Wood");
            Assert.AreEqual(false, resp.Success);
        }
    }
}
