using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Yathzee
{
    /// <summary>
    /// Class responsible for creating Die objects.
    /// </summary>
    public class DiceGenerator
    {
        Random rnd;
        public DiceGenerator()
        {
            rnd = new Random();
        }
        /// <summary>
        /// Creates a Die object using a random number generator.
        /// </summary>
        /// <returns>A Die object.</returns>
        public Die generateDice()
        {    
            int value = rnd.Next(6) + 1;
            Die die = new Die(value);
            return die;
        }
    }
}
