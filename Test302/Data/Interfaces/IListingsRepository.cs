using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Queries;
using Model.Tables;

namespace Data.Interfaces
{
   public interface IListingsRepository
    {
        Listing GetById(int listingId);
        void Insert(Listing listing);
        void Update(Listing listing);
        void Delete(int listingId);
        IEnumerable<ListingShortItem> GetRecent();
        ListingItem GetDetails(int listingId);
        IEnumerable<ListingShortItem> Search(ListingSearchParameters parameters);
    }
}
