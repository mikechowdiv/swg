using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarDealer1.Models;
using CarDealer1.Utilities;
using Data.Factories;
using Model.Tables;

namespace CarDealer1.Controllers
{
    public class ListingsController : Controller
    {
        // GET: Listings
        public ActionResult Details(int id)
        {
            if (Request.IsAuthenticated)
            {
                ViewBag.UserId = AuthorizeUtilities.GetUserId(this);
            }

            var repo = ListingRepositoryFactory.GetRepository();
            var model = repo.GetDetails(id);

            return View(model);
        }

        public ActionResult Index()
        {
            var repo = StatesRepositoryFactory.GetRepository();

            return View(repo.GetAll());
        }

        [System.Web.Http.Authorize]
        public ActionResult Add()
        {
            var model = new ListingAddViewModel();

            var statesRepo = StatesRepositoryFactory.GetRepository();
            var makesRepo = MakesRespositoryFactory.GetRepository();

            model.States = new SelectList(statesRepo.GetAll(), "StateId", "StateId");
            model.MakesTypes = new SelectList(makesRepo.GetAll(), "MakesId", "MakesName");
            model.Listing = new Listing();

            return View(model);
        }

        [System.Web.Http.Authorize]
        [System.Web.Mvc.HttpPost]
        public ActionResult Add(ListingAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var repo = ListingRepositoryFactory.GetRepository();

                try
                {
                    model.Listing.UserId = AuthorizeUtilities.GetUserId(this);

                    if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                    {
                        var savepath = Server.MapPath("~/Images");

                        string fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                        string extension = Path.GetExtension(model.ImageUpload.FileName);

                        var filePath = Path.Combine(savepath, fileName + extension);

                        int counter = 1;
                        while (System.IO.File.Exists(filePath))
                        {
                            filePath = Path.Combine(savepath, fileName + counter.ToString() + extension);
                            counter++;
                        }

                        model.ImageUpload.SaveAs(filePath);
                        model.Listing.ImageFileName = Path.GetFileName(filePath);
                    }

                    repo.Insert(model.Listing);

                   // return RedirectToAction("Index");
                    return RedirectToAction("Edit", new { id = model.Listing.ListingId });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                var statesRepo = StatesRepositoryFactory.GetRepository();
                var makesRepo = MakesRespositoryFactory.GetRepository();

                model.States = new SelectList(statesRepo.GetAll(), "StateId", "StateId");
                model.MakesTypes = new SelectList(makesRepo.GetAll(), "MakesId", "MakesName");

                return View(model);
            }

        }

        [System.Web.Http.Authorize]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = new ListingEditViewModel();

            var statesRepo = StatesRepositoryFactory.GetRepository();
            var makesRepo = MakesRespositoryFactory.GetRepository();
            var listingsRepo = ListingRepositoryFactory.GetRepository();

            model.States = new SelectList(statesRepo.GetAll(), "StateId", "StateId");
            model.MakesTypes = new SelectList(makesRepo.GetAll(), "MakesId", "MakesName");
            model.Listing = listingsRepo.GetById(id);

            if (model.Listing.UserId != AuthorizeUtilities.GetUserId(this))
            {
                throw new Exception("errors");
            }

            return View(model);
        }

        [System.Web.Http.Authorize]
        [System.Web.Http.HttpPost]
        public ActionResult Edit(ListingEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var repo = ListingRepositoryFactory.GetRepository();

                try
                {
                    model.Listing.UserId = AuthorizeUtilities.GetUserId(this);
                    var oldListing = repo.GetById(model.Listing.ListingId);

                    if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                    {
                        var savepath = Server.MapPath("~/Images");

                        string fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                        string extension = Path.GetExtension(model.ImageUpload.FileName);

                        var filePath = Path.Combine(savepath, fileName + extension);

                        int counter = 1;
                        while (System.IO.File.Exists(filePath))
                        {
                            filePath = Path.Combine(savepath, fileName + counter.ToString() + extension);
                            counter++;
                        }

                        model.ImageUpload.SaveAs(filePath);
                        model.Listing.ImageFileName = Path.GetFileName(filePath);

                        // delete old file
                        var oldPath = Path.Combine(savepath, oldListing.ImageFileName);
                        if (System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }
                    else
                    {
                        // they did not replace the old file, so keep the old file name
                        model.Listing.ImageFileName = oldListing.ImageFileName;
                    }

                    repo.Update(model.Listing);

                    return RedirectToAction("Edit", new {id = model.Listing.ListingId});
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                var statesRepo = StatesRepositoryFactory.GetRepository();
                var makesRepo = MakesRespositoryFactory.GetRepository();

                model.States = new SelectList(statesRepo.GetAll(), "StateId", "StateId");
                model.MakesTypes = new SelectList(makesRepo.GetAll(), "MakesId", "MakesName");

                return View(model);
            }
        }
    }
}