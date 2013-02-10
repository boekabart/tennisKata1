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
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NewGame_NoWinner()
        {
            const bool expected = false;
            var actual = new Game().HasWinner;
            Assert.AreEqual(expected, actual);
        }
    }
}
