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
                case 2:
                    dieImage = image.getDie2();
                    break;
                case 3:
                    dieImage = image.getDie3();
                    break;
                case 4:
                    dieImage = image.getDie4();
                    break;
                case 5:
                    dieImage = image.getDie5();
                    break;
                case 6:
                    dieImage = image.getDie6();
                    break;
                default:
                    dieImage = image.getDieBlank();
                    break;
            }
        }

        public System.Drawing.Image getDieImage()
        {
            return dieImage;
        }

        public int getDieValue()
        {
            return dieValue;
        }
    }
}
