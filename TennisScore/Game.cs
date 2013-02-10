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
        private int m_Player2Scores;

        public bool HasWinner
        {
            get { return IsPlayer1Winner || IsPlayer2Winner; }
        }

        private bool IsPlayer1Winner
        {
            get { return m_Player1Scores >= 4 && m_Player1Scores - m_Player2Scores >= 2; }
        }

        private bool IsPlayer2Winner
        {
            get { return m_Player2Scores >= 4 && m_Player2Scores - m_Player1Scores >= 2; }
        }

        public string ScoreString
        {
            get
            {
                return IsDeuce ? "deuce" : NumberScoreString;
            }
        }

        private string NumberScoreString
        {
            get { return string.Format("{0}-{1}", m_Scores2Points[m_Player1Scores], m_Scores2Points[m_Player2Scores]); }
        }

        private bool IsDeuce
        {
            get { return m_Player1Scores >= 3 && m_Player1Scores == m_Player2Scores; }
        }

        public int Winner
        {
            get { return IsPlayer1Winner ? 1 : 2; }
        }

        public void Player1Scores()
        {
            if (HasWinner)
                throw new InvalidOperationException();
            m_Player1Scores++;
        }

        public void Player2Scores()
        {
            m_Player2Scores++;
        }
    }
}
