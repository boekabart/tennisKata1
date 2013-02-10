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
            get { throw new NotImplementedException(); }
        }
    }
}
