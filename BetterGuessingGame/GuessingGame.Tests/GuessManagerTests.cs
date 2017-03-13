using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuessingGame.BLL;
using NUnit.Framework;

namespace GuessingGame.Tests
{
    [TestFixture]
    public class GuessManagerTests
    {
        [Test]
        public void InvalidGuessTest()
        {
            GuessManager mgr = new GuessManager();
            mgr.Start();
            var actual = mgr.ProcessGuess(152);
            Assert.AreEqual(GuessResult.Invalid, actual);
        }

        [Test]
        public void ValidGuessTest()
        {
            GuessManager mgr = new GuessManager();
            mgr.Start();
            var actual = mgr.ProcessGuess(10);
            Assert.AreNotEqual(GuessResult.Invalid, actual);
        }

        [TestCase(5, GuessResult.Higher)]
        [TestCase(11, GuessResult.Lower)]
        [TestCase(10, GuessResult.Win)]
        public void GuessResultTest(int guess, GuessResult expected)
        {
            GuessManager mgr = new GuessManager();
            mgr.Start(10);
            var actual = mgr.ProcessGuess(guess);
            Assert.AreEqual(expected, actual);
        }
    }
}
