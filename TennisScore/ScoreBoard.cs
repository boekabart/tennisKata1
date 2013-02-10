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
        private readonly string m_Player1Name;

        public ScoreBoard(Game game, string player1Name, string player2Name)
        {
            m_Game = game;
            m_Player1Name = player1Name;
        }

        public string DisplayString
        {
            get { return m_Game.HasWinner ? string.Format("{0} wins", m_Player1Name) : m_Game.ScoreString; }
        }
    }
}
