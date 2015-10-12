using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yathzee
{
    public enum ScoreTypeUpper
    {
        One, Two, Three, Four, Five, Six, Bonus, Total
    };
    public enum ScoreTypeLower
    {
        ThreeOfKind, FourOfKind, FullHouse, SmallStraight, LargeStraight,
        Yathzee, Chance, Total
    };    

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Die[] dice = new Die[5];

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            setAllEnabled(false);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            PictureBox[] pictureBoxes = new PictureBox[5] { pictureBox1, pictureBox2, pictureBox3,
                pictureBox4, pictureBox5 };

            CheckBox[] check = new CheckBox[5] { checkBox1, checkBox2, checkBox3, 
                checkBox4, checkBox5 };
            DiceGenerator generator = new DiceGenerator();
            for (int i = 0; i < dice.Length; i++)
            {
                if (!check[i].Checked)
                {
                    dice[i] = generator.generateDice();
                    pictureBoxes[i].Image = dice[i].getDieImage();
                    //check[i].Text = dice[i].getDieValue().ToString();
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            setAllEnabled(true);
        }

        private void setAllEnabled(bool isEnabled)
        {
            CheckBox[] holds = new CheckBox[] { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5 };
            CheckBox[] upperSection = new CheckBox[] { checkBox6, checkBox7, checkBox8, checkBox9, checkBox10, checkBox11 };
            CheckBox[] lowerSection = new CheckBox[] { checkBox12, checkBox13, checkBox14, checkBox15, checkBox16, checkBox17, checkBox18 };

            for (int i = 0; i < holds.Length; i++)
            {
                holds[i].Enabled = isEnabled;
            }

            for (int i = 0; i < upperSection.Length; i++)
            {
                if(upperSection[i].Checked)
                {
                    upperSection[i].Enabled = false;
                }
                else
                {
                    upperSection[i].Enabled = isEnabled;
                }
            }

            for (int i = 0; i < lowerSection.Length; i++)
            {
                if (lowerSection[i].Checked)
                {
                    lowerSection[i].Enabled = false;
                }
                else
                {
                    lowerSection[i].Enabled = isEnabled;
                }
            }
        }
    }
}
