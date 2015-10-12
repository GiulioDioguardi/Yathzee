using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yathzee
{
    public abstract class ScoreSection
    {
        private int total;
        public ScoreSection()
        { }

        public int getTotal()
        {
            return total;
        }

        public void setTotal(int value)
        {
            total = value;
        }

        private bool areAllSet()
        {
            return false;
        }
    }
}
