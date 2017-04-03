using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Queries;

namespace Data.Interfaces
{
   public interface IAccountRepository
    {
        IEnumerable<FeaturesItem> GetFeatures(string userId);
        IEnumerable<ContactRequestItem> GetContacts(string userId);
        IEnumerable<ListingItem> GetListings(string userId);
        void AddFeatures(string userId, int listingId);
        void RemoveFeatures(string userId, int listingId);
        void AddContact(string userId, int listingId);
        void RemoveContact(string userId, int listingId);
        bool IsFeatures(string userId, int listingId);
        bool IsContact(string userId, int listingId);
    }
}
