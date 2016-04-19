using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yathzee
{
    /// <summary>
    /// Abstract class for score section.
    /// </summary>
    public abstract class ScoreSection
    {
        /// <summary>
        /// Attribute that holds the total value of a score section.
        /// </summary>
        private int total;
        public int Total { get { return total; } set { total = value; } }
    }
}
