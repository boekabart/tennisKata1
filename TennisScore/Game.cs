using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisScore
{
    public class Game
    {
        private int m_Player1Scores;

        public bool HasWinner
        {
            get { return m_Player1Scores == 4; }
        }

        public string ScoreString
        {
            get { return "0-0"; }
        }

        public void Player1Scores()
        {
            m_Player1Scores++;
        }
    }
}
