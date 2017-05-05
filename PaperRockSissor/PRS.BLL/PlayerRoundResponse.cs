using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRS.BLL
{
    public class PlayerRoundResponse
    {
        public Choice UserChoice { get; set; }
        public Choice ComputerChoice { get; set; }
        public GameResult Result { get; set; }
    }
}
