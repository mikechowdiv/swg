using SGBank.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL
{
    public static class AccountManagerFactory
    {
        public static AccountManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];

            switch(mode)
            {
                case "FreeTest":
                    return new AccountManager(new FreeAccountTestRepository());
                case "BasicTest":
                    return new AccountManager(new BasicAccountTestRespository());
                case "PremiumTest":
                    return new AccountManager(new PremiumAcctTestRepo());
                case "FileAccount":
                    return new AccountManager(new FileAccountRespository());
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
