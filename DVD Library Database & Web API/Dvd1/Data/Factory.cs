using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Interfaces;
using Data.Repo;

namespace Data
{
    public class Factory
    {
        public static IDvdsRepo GetMode()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            if (mode == "ADO")
            {
                ADORepo repo = new ADORepo();
                return repo;
            }
            else if (mode == "DAP")
            {
                DapperRepo repo = new DapperRepo();
                return repo;
            }
            else
            {
                MockRepo repo = new MockRepo();
                return repo;
            }
        }
    }
}
