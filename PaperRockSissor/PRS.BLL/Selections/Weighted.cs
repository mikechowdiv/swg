using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRS.BLL.Interfaces;

namespace PRS.BLL.Selections
{
    public class Weighted : IChoiceGetter
    {
        private Random _rng = new Random();

        public Choice GetChoice()
        {
            int i = _rng.Next(1, 101);
            if(i <= 50)
                return Choice.Rock;
            if (i <= 80)
                return Choice.Scissors;

            return Choice.Paper;
        }
    }
}
