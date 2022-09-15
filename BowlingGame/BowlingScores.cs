using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame
{
    public class BowlingScores
    {
        /* ASSUMPTIONS:
         *  
         *  Input will be all correct, splayed out as an item in the array, up to a max size of 12
         *  where there is a strike at the 10th & 11th frame.
         *  
         *  Note that a strike takes up the whole frame (be wary in indexing).
         *         
         */

        private const char SPARE = '/';
        private const char STRIKE = 'X';
        private const int TEN = 10;

        public int ReturnTheCorrectScoreForDigitsAndSpare(char input)
        {
            if (Char.IsDigit(input)) // Ignore X,/.-
            {
                return Convert.ToInt32(Char.GetNumericValue(input));
            }
            else if (input.Equals(SPARE)) // Add 10 and next frame
            {
                return TEN;
            }
            else
            {
                return 0;
            }
        }
        public int CalculateScores(char[] input)
        {
            int score = 0;

            foreach (var c in input.Select((value, i) => (value, i)))
            {
                if (c.i <= 19) // && c.i != 11)
                {
                    //Console.WriteLine("value and index: " + c);
                    score += ReturnTheCorrectScoreForDigitsAndSpare(c.value);
                }

                // if index is 10 (11th frame) possible for spare don't count itself again
                // if index is 11 (12th frame) possible for strike, don't count it again                
                
                if (c.value.Equals(STRIKE) && c.i <=9) // Add 10 and next two frames except for when index is at 10&11 
                {                                                     // (less when there was a strike, not coded yet)          
                    score += TEN;

                    {
                        if (c.i < input.Length - 1)
                        {
                            if (input[c.i + 1].Equals(STRIKE))
                            {
                                score += TEN;
                            }
                            else
                            {

                                score += Convert.ToInt32(Char.GetNumericValue(input[c.i + 1]));
                            }
                        }

                        if (c.i < input.Length - 2)
                        {
                            if (input[c.i + 2].Equals(STRIKE))
                            {
                                score += TEN;
                            }
                            else
                            {
                                score += Convert.ToInt32(Char.GetNumericValue(input[c.i + 2]));
                            }
                        }
                    }
                }            
            }
            return score;
        }
    }
}
