using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yathzee
{
    public class Die
    {
        DieImage image = new DieImage();
        public int Value { get; private set; }
        public System.Drawing.Image Image { get; private set; }

        public Die()
        { }

        public Die(int value)
        {
            setDie(value);
        }

        public void setDie(int value)
        {
            Value = value;
            switch (value)
            {
                case 1:
                    Image = image.getDie1();
                    break;
                case 2:
                    Image = image.getDie2();
                    break;
                case 3:
                    Image = image.getDie3();
                    break;
                case 4:
                    Image = image.getDie4();
                    break;
                case 5:
                    Image = image.getDie5();
                    break;
                case 6:
                    Image = image.getDie6();
                    break;
                default:
                    Image = image.getDieBlank();
                    break;
            }
        }
    }
}
