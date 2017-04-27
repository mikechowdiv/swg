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
using NUnit.Framework.Internal;

namespace Tests
{
   [TestFixture]
    public class TestTax
    {
        [Test]
        public void GetTax()
        {
            IStateRepo repo = new TestTaxRepo();
            TaxMgr tm = new TaxMgr(repo);
            TaxResponse resp = tm.GetTaxes("OH");
            StateTax tax = resp.StateTax;
            Assert.IsNotNull(tax);
        }

        [Test]
        public void GetTaxFail()
        {
            IStateRepo repo = new TestTaxRepo();
            TaxMgr tm = new TaxMgr(repo);
            TaxResponse resp = tm.GetTaxes("OHO");
            Assert.AreEqual(false, resp.Success);
            
        }
    }
}
