using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.Factories;

namespace CarDealer1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = ListingRepositoryFactory.GetRepository().GetRecent();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}