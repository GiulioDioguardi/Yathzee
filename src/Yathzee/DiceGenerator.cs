using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Yathzee
{
    public class DiceGenerator
    {
        Random rnd = new Random();
        public Die generateDice()
        {    
            int value = rnd.Next(6) + 1;
            Die die = new Die(value);
            return die;
        }
    }
}
