using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PRS.BLL;

namespace PRS.Tests
{
    [TestFixture]
    public class GameManagerTests
    {
        [Test]
        public void PaperBeatsRock()
        {
            var userChoice = Choice.Rock;
            var x = new GameManager(new AlwaysPaper());

            var result = x.PlayerRound(userChoice);
            Assert.AreEqual(result.Result, GameResult.Loss);
        }
    }
}
