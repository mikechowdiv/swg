using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Interfaces;
using Models.Tables;
using Dapper;

namespace Data.Repo
{
    public class DapperRepo : IDvdsRepo
    {
        public void DeleteDvdId(int dvdId)
        {
            using (SqlConnection cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@dvdId", dvdId);
                cn.Execute("DeleteDvdId", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public Dvds GetDvdId(int dvdId)
        {
            using (SqlConnection cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@dvdId", dvdId);

                return
                    cn.Query<Dvds>("GetDvdId", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public List<Dvds> GetDvds()
        {
            using (SqlConnection cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var parameters = new DynamicParameters();

                return
                    cn.Query<Dvds>("GetDvds", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<Dvds> GetDvdsDirector(string director)
        {
            using (SqlConnection cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@director", director);
                
                return cn.Query<Dvds>("GetDvdsDirector", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<Dvds> GetDvdsRating(string rating)
        {
            using (SqlConnection cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@rating", rating);

                return cn.Query<Dvds>("GetDvdsRating", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<Dvds> GetDvdsYear(string releaseYear)
        {
            using (SqlConnection cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@releaseYear", releaseYear);

                return cn.Query<Dvds>("GetDvdsYear", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<Dvds> GetsDvdsTitle(string title)
        {
            using (SqlConnection cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@title", title);

                return cn.Query<Dvds>("GetsDvdsTitle", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public void PostDvd(Dvds dvd)
        {
            using (SqlConnection cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var parameters = new DynamicParameters();

                parameters.Add("@dvdId", dvd.dvdId);
                parameters.Add("@title", dvd.title);
                parameters.Add("@releaseYear", dvd.releaseYear);
                parameters.Add("@director", dvd.director);
                parameters.Add("@rating", dvd.rating);
                parameters.Add("@notes", dvd.notes);

                cn.Execute("PostDvd", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateDvdId(Dvds dvd)
        {
            using (SqlConnection cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var parameters = new DynamicParameters();

                parameters.Add("@dvdId", dvd.dvdId);
                parameters.Add("@title", dvd.title);
                parameters.Add("@director", dvd.director);
                parameters.Add("@rating", dvd.rating);
                parameters.Add("@releaseYear", dvd.releaseYear);
                parameters.Add("@notes", dvd.notes);

                cn.Execute("UpdateDvdId", parameters, commandType: CommandType.StoredProcedure);

            }
        }
    }
}
