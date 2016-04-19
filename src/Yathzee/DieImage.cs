using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yathzee
{
    /// <summary>
    /// Gets the proper image for a die value.
    /// </summary>
    public class DieImage
    {
        private System.Drawing.Image die1 = global::Yathzee.Properties.Resources.die1;
        private System.Drawing.Image die2 = global::Yathzee.Properties.Resources.die2;
        private System.Drawing.Image die3 = global::Yathzee.Properties.Resources.die3;
        private System.Drawing.Image die4 = global::Yathzee.Properties.Resources.die4;
        private System.Drawing.Image die5 = global::Yathzee.Properties.Resources.die5;
        private System.Drawing.Image die6 = global::Yathzee.Properties.Resources.die6;
        private System.Drawing.Image dieBlank = global::Yathzee.Properties.Resources.dieBlank;

        public System.Drawing.Image getDie1()
        {
            return die1;
        }

        public System.Drawing.Image getDie2()
        {
            return die2;
        }

        public System.Drawing.Image getDie3()
        {
            return die3;
        }

        public System.Drawing.Image getDie4()
        {
            return die4;
        }

        public System.Drawing.Image getDie5()
        {
            return die5;
        }

        public System.Drawing.Image getDie6()
        {
            return die6;
        }

        public System.Drawing.Image getDieBlank()
        {
            return dieBlank;
        }
    }
}
