using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame
{
    public class BowlingScores
    {
        public int CalculateScores(char[] input)
        {
            int score = 0;

            foreach (char c in input)
            {
               // if (c != 'X' || c != '/' || c != '-')
                //{
                    
                    score += Convert.ToInt32(Char.GetNumericValue(c)); // GetNumericValue will ignore non-numbers like /,-
                //}
            }
            return score;
        }
    }
}
