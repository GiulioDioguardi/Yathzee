using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Yathzee
{
    public class DiceGenerator
    {
        public Die generateDice()
        {
            Random rnd = new Random();
            int value = rnd.Next(1, 6);
            Die die = new Die(value);
            return die;
        }
    }
}
