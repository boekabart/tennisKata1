﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TennisScore;

namespace TennisScoreTest
{
    [TestFixture]
    class ScoreBoardTest
    {
        private Game m_Game;

        [SetUp]
        public void SetUp()
        {
            m_Game = new Game();
        }

        [Test]
        public void NewGame_Print_0_0()
        {
            const string expected = "0-0";
            var scoreBoard = new ScoreBoard(m_Game);
            var actual = scoreBoard.DisplayString;
            Assert.AreEqual(expected, actual);
        }
    }
}
