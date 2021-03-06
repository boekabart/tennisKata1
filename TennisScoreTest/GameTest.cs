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
            var actual = game.HasWinner;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Player1Scores_Score15_0()
        {
            var game = new Game();
            const string expected = "15-0";
            game.Player1Scores();
            var actual = game.ScoreString;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Player1ScoresThrice_Score40_0()
        {
            var game = new Game();
            const string expected = "40-0";
            game.Player1Scores();
            game.Player1Scores();
            game.Player1Scores();
            var actual = game.ScoreString;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Player1ScoresThrice_Player2ScoresOnce_Score40_15()
        {
            var game = new Game();
            const string expected = "40-15";
            game.Player1Scores();
            game.Player1Scores();
            game.Player1Scores();
            game.Player2Scores();
            var actual = game.ScoreString;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Player1Advantage_NoWinner()
        {
            const bool expected = false;
            var game = new Game();
            game.Player1Scores();
            game.Player2Scores();
            game.Player1Scores();
            game.Player2Scores();
            game.Player1Scores();
            game.Player2Scores();
            game.Player1Scores();
            var actual = game.HasWinner;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Intermezzo_ScoringWhenAWinnerThrows()
        {
            var game = new Game();
            game.Player1Scores();
            game.Player1Scores();
            game.Player1Scores();
            game.Player1Scores();
            Assert.Throws<InvalidOperationException>(game.Player1Scores);
        }

        [Test]
        public void Player2LoveGame_AWinner()
        {
            const bool expected = true;
            var game = new Game();
            game.Player2Scores();
            game.Player2Scores();
            game.Player2Scores();
            game.Player2Scores();
            var actual = game.HasWinner;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Player2LoveGame_Player2Wins()
        {
            const int expected = 2;
            var game = new Game();
            game.Player2Scores();
            game.Player2Scores();
            game.Player2Scores();
            game.Player2Scores();
            var actual = game.Winner;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Player1LoveGame_Player1Wins()
        {
            const int expected = 1;
            var game = new Game();
            game.Player1Scores();
            game.Player1Scores();
            game.Player1Scores();
            game.Player1Scores();
            var actual = game.Winner;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Deuce_ScoreDeuce()
        {
            const string expected = "deuce";
            var game = new Game();
            game.Player1Scores();
            game.Player2Scores();
            game.Player1Scores();
            game.Player2Scores();
            game.Player1Scores();
            game.Player2Scores();
            var actual = game.ScoreString;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AdvantagePlayer1_ScoreAD_40()
        {
            const string expected = "AD-40";
            var game = new Game();
            game.Player1Scores();
            game.Player2Scores();
            game.Player1Scores();
            game.Player2Scores();
            game.Player1Scores();
            game.Player2Scores();
            game.Player1Scores();
            var actual = game.ScoreString;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SecondAdvantagePlayer2_Score40_AD()
        {
            const string expected = "40-AD";
            var game = new Game();
            game.Player2Scores();
            game.Player1Scores();
            game.Player2Scores();
            game.Player1Scores();
            game.Player2Scores();
            game.Player1Scores();
            game.Player2Scores();
            game.Player1Scores();
            game.Player2Scores();
            var actual = game.ScoreString;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Intermezzo_ScoringWhenAWinnerThrows2()
        {
            var game = new Game();
            game.Player1Scores();
            game.Player1Scores();
            game.Player1Scores();
            game.Player1Scores();
            Assert.Throws<InvalidOperationException>(game.Player2Scores);
        }

        [Test]
        public void Intermezzo_ThrowWhenRequestingWinnerIfNoWinner()
        {
            var game = new Game();
            Assert.Throws<InvalidOperationException>(() => { var irrelevant = game.Winner; });
        }
    }
}
