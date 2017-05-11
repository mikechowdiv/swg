using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Tables;

namespace Data.Interfaces
{
    public interface IDvdsRepo
    {
        Dvds GetDvdId(int dvdId);
        List<Dvds> GetDvds();
        List<Dvds> GetDvdsDirector(string director);
        List<Dvds> GetDvdsRating(string rating);
        List<Dvds> GetsDvdsTitle(string title);
        List<Dvds> GetDvdsYear(string releaseYear);
        void PostDvd(Dvds dvd);
        void DeleteDvdId(int dvdId);
        void UpdateDvdId(Dvds dvd);

    }
}
