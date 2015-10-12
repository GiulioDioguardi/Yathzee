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
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            PictureBox[] box = new PictureBox[5] { pictureBox1, pictureBox2, pictureBox3,
                pictureBox4, pictureBox5 };
            CheckBox[] check = new CheckBox[5] { checkBox1, checkBox2, checkBox3, 
                checkBox4, checkBox5 };
            DiceGenerator generator = new DiceGenerator();
            for (int i = 0; i < dice.Length; i++)
            {
                if (!check[i].Checked)
                {
                    dice[i] = generator.generateDice();
                    box[i].Image = dice[i].getDieImage();
                }
            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
        }


    }
}
