using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRS.BLL.Interfaces;

namespace PRS.BLL.Selections
{
    public class dumbVersion : IChoiceGetter
    {
        public Choice GetChoice()
        {
            return Choice.Rock;
        }
    }
}
