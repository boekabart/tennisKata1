using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisScore
{
    public class ScoreBoard
    {
        private readonly Game m_Game;

        public ScoreBoard(Game game, string player1Name, string player2Name)
        {
            m_Game = game;
        }

        public string DisplayString
        {
            get { return m_Game.ScoreString; }
        }
    }
}
