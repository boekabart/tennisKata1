using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisScore
{
    public class Game
    {
        public bool HasWinner
        {
            get { return false; }
        }

        public string ScoreString
        {
            get { return "0-0"; }
        }

        public void Player1Scores()
        {
            throw new NotImplementedException();
        }
    }
}
