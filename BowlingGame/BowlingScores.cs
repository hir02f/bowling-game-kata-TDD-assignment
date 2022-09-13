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
        private const char SPARE = '/';
        private const char STRIKE = 'X';
        private const int TEN = 10;

        public int ReturnTheCorrectScore(char input)
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
              
                score += ReturnTheCorrectScore(c.value);
                
                if (c.value.Equals(STRIKE)) // Add 10 and next two frames
                {
                    score += TEN; 
                    
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
            return score;
        }
    }
}
