using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TennisScore;

namespace TennisScoreTest
{
    public class GameTest
    {
        [Test]
        void NewGame_NoWinner()
        {
            var expected = false;
            var actual = new Game().HasWinner;
            Assert.AreEqual(expected, actual);
        }
    }
}
