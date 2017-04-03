using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarDealer1.Models;
using CarDealer1.Utilities;
using Data.Factories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace CarDealer1.Controllers
{
    [Authorize]
    public class MyAccountController : Controller
    {
        
        // GET: MyAccount
       
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: MyAccount
        public ActionResult Index()
        {
            var userId = AuthorizeUtilities.GetUserId(this);

            var repo = AccountRepositoryFactory.GetRepository();
            var model = repo.GetListings(userId);
            return View(model);
        }

        public ActionResult Favorites()
        {
            var userId = AuthorizeUtilities.GetUserId(this);

            var repo = AccountRepositoryFactory.GetRepository();
            var model = repo.GetFeatures(userId);
            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteFavorite(int ListingId)
        {
            var userId = AuthorizeUtilities.GetUserId(this);

            var repo = AccountRepositoryFactory.GetRepository();
            repo.RemoveFeatures(userId, ListingId);

            return RedirectToAction("Favorites");
        }

        public ActionResult Contacts()
        {
            var userId = AuthorizeUtilities.GetUserId(this);

            var repo = AccountRepositoryFactory.GetRepository();
            var model = repo.GetContacts(userId);
            return View(model);
        }

        public ActionResult UpdateAccount()
        {
            var model = new UpdateAccountViewModel();
            var statesRepo = StatesRepositoryFactory.GetRepository();
            model.States = new SelectList(statesRepo.GetAll(), "StateId", "StateId");
            model.EmailAddress = User.Identity.Name;

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateAccount(UpdateAccountViewModel model)
        {
            var currentUser = UserManager.FindByEmail(User.Identity.Name);
            currentUser.UserName = model.EmailAddress;
            currentUser.Email = model.EmailAddress;
            //currentUser.StateId = model.StateId;

            UserManager.Update(currentUser);

            return RedirectToAction("UpdateAccount");
        }
    
    }
}