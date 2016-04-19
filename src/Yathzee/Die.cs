using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yathzee
{
    /// <summary>
    /// Die objects are objects that have a die value, and a DieImage
    /// </summary>
    public class Die
    {
        /// <summary>
        /// Attribute that holds the DieImage
        /// </summary>
        System.Drawing.Image dieImage;
        /// <summary>
        /// Attribute that holds the die value
        /// </summary>
        int dieValue;

        public int Value { get { return dieValue; } private set { dieValue = value; } }
        public System.Drawing.Image Image { get { return dieImage; } private set { dieImage = value; } }

        public Die(int value)
        {
            setDie(value);
        }

        /// <summary>
        /// Initializes the Die object. Sets a DieImage based on parameter value.
        /// </summary>
        /// <param name="value">The value of the Die object to be set.</param>
        public void setDie(int value)
        {
            DieImage image = new DieImage();
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
