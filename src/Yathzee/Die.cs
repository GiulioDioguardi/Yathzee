using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yathzee
{
    class Die
    {
        DieImage image = new DieImage();
        private int dieValue;
        private System.Drawing.Image dieImage;

        public void setDie(int value)
        {
            dieValue = value;
            switch (value)
            {
                case 1:
                    dieImage = image.getDie1();
                    break;

            }
        }
    }
}
