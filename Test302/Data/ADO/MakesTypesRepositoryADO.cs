using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Interfaces;
using Model.Tables;

namespace Data.ADO
{
    public class MakesTypesRepositoryADO : IMakesRepository
    {
        public List<MakesType> GetAll()
        {
            List<MakesType> makesTypes = new List<MakesType>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakesSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        MakesType currentRow = new MakesType();
                        currentRow.MakesId = (int)dr["MakesId"];
                        currentRow.MakesName = dr["MakesName"].ToString();

                        makesTypes.Add(currentRow);
                    }
                }
            }

            return makesTypes;
        }
    }
}
