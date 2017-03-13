using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame.BLL
{
    public class GuessManager
    {
        private int _answer;

        private bool isValidGuess(int guess)
        {
            return (guess >= 1 && guess <= 20);
        }

        private void CreateRandomAnswer()
        {
            Random rng = new Random();
            _answer = rng.Next(1, 21);
        }

        public GuessResult ProcessGuess(int guess)
        {
            if (!isValidGuess(guess))
            {
                return GuessResult.Invalid;
            }
            if (guess < _answer)
            {
                return GuessResult.Higher;
            }
            else if (guess > _answer)
            {
                return GuessResult.Lower;
            }
            else
            {
                return GuessResult.Win;
            }
        }

        public void Start()
        {
            CreateRandomAnswer();
        }

        public void Start(int answer)
        {
            _answer = answer;
        }
    }
}
