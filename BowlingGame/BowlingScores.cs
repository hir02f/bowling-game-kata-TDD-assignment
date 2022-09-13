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
                if (Char.IsDigit(c)) // Ignore X,/.-
                {                   
                    score += Convert.ToInt32(Char.GetNumericValue(c)); 
                }                
            }
            return score;
        }
    }
}
