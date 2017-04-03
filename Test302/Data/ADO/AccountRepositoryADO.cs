using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Interfaces;
using Model.Queries;

namespace Data.ADO
{
    public class AccountRepositoryADO : IAccountRepository
    {
        public void AddContact(string userId, int listingId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ContactsInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ListingId", listingId);
                cmd.Parameters.AddWithValue("@UserId", userId);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void AddFeatures(string userId, int listingId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("FeaturesInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ListingId", listingId);
                cmd.Parameters.AddWithValue("@UserId", userId);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<ContactRequestItem> GetContacts(string userId)
        {
            List<ContactRequestItem> listings = new List<ContactRequestItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ListingsSelectContacts", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserId", userId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ContactRequestItem row = new ContactRequestItem();

                        row.ListingId = (int)dr["ListingId"];
                        row.UserId = dr["UserId"].ToString();
                        row.StateId = dr["StateId"].ToString();
                        row.City = dr["City"].ToString();
                        row.Rate = (decimal)dr["Rate"];
                        row.Email = dr["Email"].ToString();
                        row.Year = (int)dr["Year"];

                        listings.Add(row);
                    }
                }
            }

            return listings;

        }

        public IEnumerable<FeaturesItem> GetFeatures(string userId)
        {
            List<FeaturesItem> listings = new List<FeaturesItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ListingsSelectFeatures", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserId", userId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        FeaturesItem row = new FeaturesItem();

                        row.ListingId = (int)dr["ListingId"];
                        row.UserId = dr["UserId"].ToString();
                        row.StateId = dr["StateId"].ToString();
                        row.City = dr["City"].ToString();
                        row.Rate = (decimal)dr["Rate"];
                        row.MakesId = (int)dr["MakesId"];
                        row.MakesName = dr["MakesName"].ToString();
                        row.Mileage = (decimal)dr["Mileage"];
                        row.isNew = (bool)dr["isNew"];
                        row.isManual = (bool)dr["isManual"];


                        listings.Add(row);
                    }
                }
            }

            return listings;
        }


        public IEnumerable<ListingItem> GetListings(string userId)
        {
            List<ListingItem> listings = new List<ListingItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ListingsSelectByUser", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserId", userId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ListingItem row = new ListingItem();

                        row.ListingId = (int)dr["ListingId"];
                        row.UserId = dr["UserId"].ToString();
                        row.Year = (int)dr["Year"];
                        row.StateId = dr["StateId"].ToString();
                        row.City = dr["City"].ToString();
                        row.Rate = (decimal)dr["Rate"];
                        row.Mileage = (decimal)dr["Mileage"];
                        row.isNew = (bool)dr["isNew"];
                        row.isManual = (bool)dr["isManual"];
                        row.MakesName = dr["MakesName"].ToString();
                        row.MakesId = (int)dr["MakesId"];

                        if (dr["ImageFileName"] != DBNull.Value)
                            row.ImageFileName = dr["ImageFileName"].ToString();

                        listings.Add(row);
                    }
                }
            }

            return listings;
        }

        public bool IsContact(string userId, int listingId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ContactsSelect", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ListingId", listingId);
                cmd.Parameters.AddWithValue("@UserId", userId);

                cn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    return dr.Read();
                }
            }
        }

        public bool IsFeatures(string userId, int listingId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("FeaturesSelect", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ListingId", listingId);
                cmd.Parameters.AddWithValue("@UserId", userId);

                cn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    return dr.Read();
                }
            }
        }

        public void RemoveContact(string userId, int listingId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ContactsDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ListingId", listingId);
                cmd.Parameters.AddWithValue("@UserId", userId);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void RemoveFeatures(string userId, int listingId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("FeaturesDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ListingId", listingId);
                cmd.Parameters.AddWithValue("@UserId", userId);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
