using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuessingGame.BLL;

namespace BetterGuessingGame
{
    public class GameFlow
    {
        private GuessManager _manager;

        public void PlayGame()
        {
            ConsoleOutput.DisplayTitle();
            CreateGameManagerInstance();
            GuessResult result;
            int guess;

            do
            {
                guess = ConsoleInput.GetGuessFromUser();
                result = _manager.ProcessGuess(guess);
                ConsoleOutput.DisplayGuessMessage(result);
            } while (result != GuessResult.Win);
        }

        private void CreateGameManagerInstance()
        {
            _manager = new GuessManager();
            _manager.Start();
        }
    }
}
