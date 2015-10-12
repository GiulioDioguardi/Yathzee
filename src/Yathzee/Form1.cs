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
        Dictionary<ScoreTypeUpper, int> upperScores = new Dictionary<ScoreTypeUpper, int>();
        UpperScoreSection upperSection = new UpperScoreSection();

        Dictionary<ScoreTypeLower, int> lowerScores = new Dictionary<ScoreTypeLower, int>();
        LowerScoreSection lowerSection = new LowerScoreSection();

        Die[] dice = new Die[5];

        int rollRemain = 3;

        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            setAllEnabled(false);
            rollRemain--;
            label36.Text = rollRemain.ToString();
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

        private void newRoll()
        {
            setAllEnabled(false);
            rollRemain = 3;
            label36.Text = rollRemain.ToString();
            button1.Enabled = true;

            CheckBox[] holds = new CheckBox[] { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5 };

            for (int i = 0; i < holds.Length; i++)
            {
                holds[i].Checked = false;
            }

        }

        private void setAllEnabled(bool isEnabled)
        {
            CheckBox[] holds = new CheckBox[] { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5 };
            CheckBox[] upperSection = new CheckBox[] { checkBox6, checkBox7, checkBox8, checkBox9, checkBox10, checkBox11 };
            CheckBox[] lowerSection = new CheckBox[] { checkBox12, checkBox13, checkBox14, checkBox15, checkBox16, checkBox17, checkBox18 };

            if (rollRemain == 0)
            {
                 button1.Enabled = false;

                for (int i = 0; i < holds.Length; i++)
                {
                    holds[i].Enabled = false;
                }
            }
            else
            {
                button1.Enabled = isEnabled;

                for (int i = 0; i < holds.Length; i++)
                {
                    holds[i].Enabled = isEnabled;
                }
            }
            for (int i = 0; i < upperSection.Length; i++)
            {
                if (upperSection[i].Checked)
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

        private void checkBoxUpperSection_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox currentCheckBox = (CheckBox)sender;
            Label currentLabel = null;
            ScoreTypeUpper scoreType = ScoreTypeUpper.Total;
            int checkedValue;
            switch (currentCheckBox.Name)
            {
                case "checkBox6":
                    scoreType = ScoreTypeUpper.One;
                    checkedValue = 1;
                    currentLabel = label2;
                    break;
                case "checkBox7":
                    scoreType = ScoreTypeUpper.Two;
                    checkedValue = 2;
                    currentLabel = label4;
                    break;
                case "checkBox8":
                    scoreType = ScoreTypeUpper.Three;
                    checkedValue = 3;
                    currentLabel = label6;
                    break;
                case "checkBox9":
                    scoreType = ScoreTypeUpper.Four;
                    checkedValue = 4;
                    currentLabel = label8;
                    break;
                case "checkBox10":
                    scoreType = ScoreTypeUpper.Five;
                    checkedValue = 5;
                    currentLabel = label10;
                    break;
                case "checkBox11":
                    scoreType = ScoreTypeUpper.Six;
                    checkedValue = 6;
                    currentLabel = label12;
                    break;
                default:
                    checkedValue = 0;
                    break;
            }

            upperScores = upperSection.checkScore(dice, checkedValue);

            currentLabel.Text = upperScores[scoreType].ToString();
            label14.Text = upperScores[ScoreTypeUpper.Bonus].ToString();

            label16.Text = upperScores[ScoreTypeUpper.Total].ToString();

            label34.Text = (upperScores[ScoreTypeUpper.Total] + lowerScores[ScoreTypeLower.Total]).ToString();

            newRoll();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            newRoll();
        }
    }
}
