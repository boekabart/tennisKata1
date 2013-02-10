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
    internal class ScoreBoardTest
    {
        private Game m_Game;
        private string m_Player1Name;
        private string m_Player2Name;

        [SetUp]
        public void SetUp()
        {
            m_Game = new Game();
            m_Player1Name = "Timo";
            m_Player2Name = "Stefan";
        }

        [Test]
        public void NewGame_Print_0_0()
        {
            const string expected = "0-0";
            var scoreBoard = new ScoreBoard(m_Game, m_Player1Name, m_Player2Name);
            var actual = scoreBoard.DisplayString;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Player1WonGame_Print_Player1Name()
        {
            var expected = string.Format("{0} wins", m_Player1Name);
            var scoreBoard = new ScoreBoard(m_Game, m_Player1Name, m_Player2Name);
            m_Game.Player1Scores();
            m_Game.Player1Scores();
            m_Game.Player1Scores();
            m_Game.Player1Scores();
            var actual = scoreBoard.DisplayString;
            Assert.AreEqual(expected, actual);
        }
    }
}
