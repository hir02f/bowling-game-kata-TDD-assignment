using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame
{
    public class BowlingScores
    {
        //private const char MISS = '-';
        private const char SPARE = '/';
        private const char STRIKE = 'X';
        private const int TEN = 10;

        public int CalculateScores(char[] input)
        {
            int score = 0;

            //foreach (char c in input)
            foreach (var c in input.Select((value, i) => (value, i)))
            {
                if (Char.IsDigit(c.value)) // Ignore X,/.-
                {                   
                    score += Convert.ToInt32(Char.GetNumericValue(c.value)); 
                }
                if (c.value.Equals(SPARE)) // Add 10 and next frame
                {
                    score += TEN;
                }
                if (c.value.Equals(STRIKE)) // Add 10 and next two frames
                {
                    score += TEN + Convert.ToInt32(Char.GetNumericValue(input[c.i+1])) + Convert.ToInt32(Char.GetNumericValue(input[c.i + 2])); 
                }
            }
            return score;
        }
    }
}
