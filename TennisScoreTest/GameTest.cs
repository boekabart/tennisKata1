using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TennisScore;

namespace TennisScoreTest
{
    [TestFixture]
    public class GameTest
    {
        [Test]
        public void NewGame_NoWinner()
        {
            const bool expected = false;
            var actual = new Game().HasWinner;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void NewGame_Score0_0()
        {
            const string expected = "0-0";
            var actual = new Game().ScoreString;
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Player1LoveGame_AWinner()
        {
            const bool expected = true;
            var game = new Game();
            game.Player1Scores();
            game.Player1Scores();
            game.Player1Scores();
            game.Player1Scores();
            var actual = new Game().HasWinner;
            Assert.AreEqual(expected, actual);
        }
    }
}
