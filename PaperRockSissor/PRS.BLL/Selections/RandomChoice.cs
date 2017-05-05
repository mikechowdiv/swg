using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRS.BLL.Interfaces;

namespace PRS.BLL.Selections
{
    public class RandomChoice : IChoiceGetter
    {
        private Random _rng = new Random();

        public Choice GetChoice()
        {
            int i = _rng.Next(0, 3);
            switch (i)
            {
                case 0:
                    return Choice.Rock;
                case 1:
                    return Choice.Paper;
                default:
                    return Choice.Scissors;
            }
        }
    }
}
