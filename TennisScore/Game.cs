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
        private readonly int[] m_Scores2Points = new[] {0, 15, 30, 40};

        public bool HasWinner
        {
            get { return m_Player1Scores == 4; }
        }

        public string ScoreString
        {
            get { return string.Format("{0}-0", m_Scores2Points[m_Player1Scores]); }
        }

        public void Player1Scores()
        {
            m_Player1Scores++;
        }

        public void Player2Scores()
        {
            throw new NotImplementedException();
        }
    }
}
