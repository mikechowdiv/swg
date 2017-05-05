using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRS.BLL;
using PRS.BLL.Interfaces;

namespace PRS.Tests
{
    public class AlwaysRock : IChoiceGetter
    {
        public Choice GetChoice()
        {
            return Choice.Rock;
        }
    }
}
