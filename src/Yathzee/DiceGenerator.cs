using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Yathzee
{
    class DiceGenerator
    {
        public Die[] generateDice()
        {
            Random rnd = new Random();
            Die[] dieCollection = new Die[5];
            for (int i = 0; i < dieCollection.Length;i++ )
            {
                Die die = new Die();
                int value = rnd.Next(1, 6);
                die.setDie(value);
                dieCollection[i] = die;
            }   
            return dieCollection;
        }
    }
}
