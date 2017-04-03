using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.ADO;
using Model.Queries;
using Model.Tables;
using NUnit.Framework;

namespace Tests.Tests
{
    [TestFixture]
   public class AdoTests
    {
        [SetUp]
        public void Init()
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "DbReset";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        [Test]
        public void CanLoadStates()
        {
            var repo = new StatesRepositoryADO();

            var states = repo.GetAll();

            Assert.AreEqual(3, states.Count);

            Assert.AreEqual("KY", states[0].StateId);
            Assert.AreEqual("Kentucky", states[0].StateName);
        }

        [Test]
        public void CanLoadMakesTypes()
        {
            var repo = new MakesTypesRepositoryADO();
            var types = repo.GetAll();

            Assert.AreEqual(3, types.Count);

            Assert.AreEqual(1, types[1].MakesId);
            Assert.AreEqual("Ford", types[1].MakesName);
        }

        [Test]
        public void CanLoadListing()
        {
            var repo = new ListingsRepositoryADO();
            var listing = repo.GetById(1);

            Assert.IsNotNull(listing);

            Assert.AreEqual(1, listing.ListingId);
            Assert.AreEqual("00000000-0000-0000-0000-000000000000", listing.UserId);
            Assert.AreEqual("OH", listing.StateId);
            Assert.AreEqual(3, listing.MakesId);
            Assert.AreEqual(2001, listing.Year);
            Assert.AreEqual("Cleveland", listing.City);
            Assert.AreEqual(100M, listing.Rate);
            Assert.AreEqual(400M, listing.Mileage);
            Assert.AreEqual(false, listing.isNew);
            Assert.AreEqual(true, listing.isManual);
            Assert.AreEqual("placeholder.png", listing.ImageFileName);
            Assert.AreEqual("Description", listing.ListingDescription);
        }

        [Test]
        public void NotFoundListingReturnsNull()
        {
            var repo = new ListingsRepositoryADO();
            var listing = repo.GetById(100000);

            Assert.IsNull(listing);
        }

        [Test]
        public void CanAddListing()
        {
            Listing listingToAdd = new Listing();
            var repo = new ListingsRepositoryADO();

            listingToAdd.UserId = "00000000-0000-0000-0000-000000000000";
            listingToAdd.StateId = "OH";
            listingToAdd.Year = 2014;
            listingToAdd.MakesId = 1;
            listingToAdd.City = "Columbus";
            listingToAdd.Rate = 50M;
            listingToAdd.Mileage = 100M;
            listingToAdd.isManual = true;
            listingToAdd.isNew = true;
            listingToAdd.ImageFileName = "placeholder.png";
            listingToAdd.ListingDescription = "Description";

            repo.Insert(listingToAdd);

            Assert.AreEqual(7, listingToAdd.ListingId);

        }

        [Test]
        public void CanUpdateListing()
        {
            Listing listingToAdd = new Listing();
            var repo = new ListingsRepositoryADO();

            listingToAdd.UserId = "00000000-0000-0000-0000-000000000000";
            listingToAdd.StateId = "OH";
            listingToAdd.Year = 2011;
            listingToAdd.MakesId = 1;
            listingToAdd.City = "Columbus";
            listingToAdd.Rate = 50M;
            listingToAdd.Mileage = 100M;
            listingToAdd.isManual = true;
            listingToAdd.isNew = true;
            listingToAdd.ImageFileName = "placeholder.png";
            listingToAdd.ListingDescription = "Description";

            repo.Insert(listingToAdd);

            listingToAdd.StateId = "KY";
            listingToAdd.Year = 2000;
            listingToAdd.MakesId = 2;
            listingToAdd.City = "Louisville";
            listingToAdd.Rate = 25M;
            listingToAdd.Mileage = 75M;
            listingToAdd.isManual = false;
            listingToAdd.isNew = false;
            listingToAdd.ImageFileName = "updated.png";
            listingToAdd.ListingDescription = "updated";

            repo.Update(listingToAdd);

            var updatedListing = repo.GetById(7);

            Assert.AreEqual("KY", updatedListing.StateId);
            Assert.AreEqual(2000, updatedListing.Year);
            Assert.AreEqual(2, updatedListing.MakesId);
            Assert.AreEqual("Louisville", updatedListing.City);
            Assert.AreEqual(25M, updatedListing.Rate);
            Assert.AreEqual(75M, updatedListing.Mileage);
            Assert.AreEqual(false, updatedListing.isManual);
            Assert.AreEqual(false, updatedListing.isNew);
            Assert.AreEqual("updated.png", updatedListing.ImageFileName);
            Assert.AreEqual("updated", updatedListing.ListingDescription);
        }

        [Test]
        public void CanDeleteListing()
        {
            Listing listingToAdd = new Listing();
            var repo = new ListingsRepositoryADO();

            listingToAdd.UserId = "00000000-0000-0000-0000-000000000000";
            listingToAdd.StateId = "OH";
            listingToAdd.Year = 2000;
            listingToAdd.MakesId = 1;
            listingToAdd.City = "Columbus";
            listingToAdd.Rate = 50M;
            listingToAdd.Mileage = 100M;
            listingToAdd.isManual = true;
            listingToAdd.isNew = true;
            listingToAdd.ImageFileName = "placeholder.png";
            listingToAdd.ListingDescription = "Description";


            repo.Insert(listingToAdd);

            var loaded = repo.GetById(7);
            Assert.IsNotNull(loaded);

            repo.Delete(7);
            loaded = repo.GetById(7);

            Assert.IsNull(loaded);
        }

        [Test]
        public void CanLoadListingDetails()
        {
            var repo = new ListingsRepositoryADO();
            var listing = repo.GetDetails(1);

            Assert.IsNotNull(listing);

            Assert.AreEqual(1, listing.ListingId);
            Assert.AreEqual("00000000-0000-0000-0000-000000000000", listing.UserId);
            Assert.AreEqual("OH", listing.StateId);
            Assert.AreEqual(3, listing.MakesId);
            Assert.AreEqual(2001, listing.Year);
            Assert.AreEqual("Cleveland", listing.City);
            Assert.AreEqual(100M, listing.Rate);
            Assert.AreEqual(400M, listing.Mileage);
            Assert.AreEqual(false, listing.isNew);
            Assert.AreEqual(true, listing.isManual);
            Assert.AreEqual("placeholder.png", listing.ImageFileName);
            Assert.AreEqual("BMW", listing.MakesName);
            Assert.AreEqual("Description", listing.ListingDescription);
        }

        [Test]
        public void CanLoadFavorites()
        {
            var repo = new AccountRepositoryADO();
            var favorites = repo.GetFeatures("11111111-1111-1111-1111-111111111111").ToList();

            Assert.AreEqual(2, favorites.Count());

            Assert.AreEqual(1, favorites[0].ListingId);
            Assert.AreEqual("00000000-0000-0000-0000-000000000000", favorites[0].UserId);
            Assert.AreEqual("OH", favorites[0].StateId);
            Assert.AreEqual("Cleveland", favorites[0].City);
            Assert.AreEqual(100M, favorites[0].Rate);
            Assert.AreEqual(400M, favorites[0].Mileage);
            Assert.AreEqual(false, favorites[0].isNew);
            Assert.AreEqual(true, favorites[0].isManual);
            Assert.AreEqual("BMW", favorites[0].MakesName);
            Assert.AreEqual(3, favorites[0].MakesId);

        }

        [Test]
        public void CanLoadContacts()
        {
            var repo = new AccountRepositoryADO();
            var contacts = repo.GetContacts("00000000-0000-0000-0000-000000000000").ToList();

            Assert.AreEqual(2, contacts.Count());

            Assert.AreEqual(1, contacts[0].ListingId);
            Assert.AreEqual("11111111-1111-1111-1111-111111111111", contacts[0].UserId);
            Assert.AreEqual("OH", contacts[0].StateId);
            Assert.AreEqual("Cleveland", contacts[0].City);
            Assert.AreEqual(100M, contacts[0].Rate);
            Assert.AreEqual("test2@test.com", contacts[0].Email);
            Assert.AreEqual(2001, contacts[0].Year);
        }

        [Test]
        public void CanLoadListingsForUser()
        {
            var repo = new AccountRepositoryADO();
            var listings = repo.GetListings("00000000-0000-0000-0000-000000000000").ToList();

            Assert.AreEqual(6, listings.Count());

            Assert.AreEqual(1, listings[0].ListingId);
            Assert.AreEqual("OH", listings[0].StateId);
            Assert.AreEqual(3, listings[0].MakesId);
            Assert.AreEqual(2001, listings[0].Year);
            Assert.AreEqual("Cleveland", listings[0].City);
            Assert.AreEqual(100M, listings[0].Rate);
            Assert.AreEqual(400M, listings[0].Mileage);
            Assert.AreEqual(false, listings[0].isNew);
            Assert.AreEqual(true, listings[0].isManual);
            Assert.AreEqual("placeholder.png", listings[0].ImageFileName);
            Assert.AreEqual("BMW", listings[0].MakesName);
        }

        [Test]
        public void CanAddAndRemoveFavorites()
        {
            var repo = new AccountRepositoryADO();

            repo.AddFeatures("11111111-1111-1111-1111-111111111111", 3);

            var favorites = repo.GetFeatures("11111111-1111-1111-1111-111111111111");

            Assert.AreEqual(3, favorites.Count());

            repo.RemoveFeatures("11111111-1111-1111-1111-111111111111", 2);

            favorites = repo.GetFeatures("11111111-1111-1111-1111-111111111111");

            Assert.AreEqual(2, favorites.Count());

        }

        [Test]
        public void CanAddAndRemoveContacts()
        {
            var repo = new AccountRepositoryADO();

            repo.AddContact("11111111-1111-1111-1111-111111111111", 5);

            var contacts = repo.GetContacts("00000000-0000-0000-0000-000000000000");

            Assert.AreEqual(3, contacts.Count());

            repo.RemoveContact("11111111-1111-1111-1111-111111111111", 3);

            contacts = repo.GetContacts("00000000-0000-0000-0000-000000000000");

            Assert.AreEqual(2, contacts.Count());

        }

        [Test]
        public void CanDetectFavorite()
        {
            var repo = new AccountRepositoryADO();

            var found = repo.IsFeatures("11111111-1111-1111-1111-111111111111", 2);

            Assert.IsTrue(found);

            found = repo.IsFeatures("11111111-1111-1111-1111-111111111111", 10);
            Assert.IsFalse(found);
        }

        [Test]
        public void CanDetectContact()
        {
            var repo = new AccountRepositoryADO();

            var found = repo.IsContact("11111111-1111-1111-1111-111111111111", 1);

            Assert.IsTrue(found);

            found = repo.IsContact("11111111-1111-1111-1111-111111111111", 10);
            Assert.IsFalse(found);
        }

        [Test]
        public void CanSearchOnMinRate()
        {
            var repo = new ListingsRepositoryADO();

            var found = repo.Search(new ListingSearchParameters { MinRate = 110M });

            Assert.AreEqual(5, found.Count());
        }

        [Test]
        public void CanSearchOnMaxRate()
        {
            var repo = new ListingsRepositoryADO();

            var found = repo.Search(new ListingSearchParameters { MaxRate = 110M });

            Assert.AreEqual(2, found.Count());
        }

        [Test]
        public void CanSearchOnRateRange()
        {
            var repo = new ListingsRepositoryADO();

            var found = repo.Search(new ListingSearchParameters { MaxRate = 120M, MinRate = 100M });

            Assert.AreEqual(3, found.Count());
        }

        [Test]
        public void CanSearchOnCity()
        {
            var repo = new ListingsRepositoryADO();

            var found = repo.Search(new ListingSearchParameters { City = "Col" });

            Assert.AreEqual(1, found.Count());

            found = repo.Search(new ListingSearchParameters { City = "Cle" });

            Assert.AreEqual(5, found.Count());
        }


    }
}
