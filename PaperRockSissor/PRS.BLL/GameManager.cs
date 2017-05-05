using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRS.BLL.Interfaces;

namespace PRS.BLL
{
    public class GameManager
    {
        private IChoiceGetter _chooser;

        public GameManager(IChoiceGetter concrete)
        {
            _chooser = concrete;
        }

        public PlayerRoundResponse PlayerRound(Choice userChoice)
        {
            PlayerRoundResponse response = new PlayerRoundResponse();
            response.UserChoice = userChoice;
            response.ComputerChoice = _chooser.GetChoice();

            if (response.ComputerChoice == response.UserChoice)
            {
                response.Result = GameResult.Tie;
                return response;
            }

            if (response.ComputerChoice == Choice.Rock && response.UserChoice == Choice.Scissors ||
                response.ComputerChoice == Choice.Scissors && response.UserChoice == Choice.Paper ||
                response.ComputerChoice == Choice.Paper && response.UserChoice == Choice.Rock)
            {
                response.Result = GameResult.Loss;
                return response;
            }

            response.Result = GameResult.Win;
            return response;
        }
    }
}
