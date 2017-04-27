using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Data;
using Data.Repo;
using Models.Interfaces;
using Models.Responses;

namespace Flooringv1.Workflows
{
   public class RemoveWorkflow
    {
       

        public void Start()
        {
            Utility ut = new Utility();
            DateTime dt = ut.inputDate();
            int orderNum = ut.InputOrderNumber();
            OrderMgr orderManager = Factory.GetOrderRepo();
            OrderResponse oResp = orderManager.DeleteOrder(dt, orderNum);
            if (!oResp.Success)
            {
                Console.WriteLine(oResp.Message);
                Console.ReadKey();
            }
        }
    }
}
