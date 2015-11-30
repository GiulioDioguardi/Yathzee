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
        public int Total { get { return total; } set { total = value; } }
    }
}
