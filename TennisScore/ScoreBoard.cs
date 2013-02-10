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
        private readonly string[] m_PlayerNames;

        public ScoreBoard(Game game, string player1Name, string player2Name)
        {
            m_Game = game;
            m_PlayerNames = new[] {player1Name, player2Name};
        }

        public string DisplayString
        {
            get
            {
                return m_Game.HasWinner
                           ? string.Format("{0} wins", m_PlayerNames[m_Game.Winner - 1])
                           : m_Game.ScoreString;
            }
        }
    }
}
