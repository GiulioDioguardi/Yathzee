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
    public enum ScoreTypeUpper : byte
    {
        One, Two, Three, Four, Five, Six, Bonus, Total
    };

    public enum ScoreTypeLower : byte
    {
        ThreeOfKind, FourOfKind, FullHouse, SmallStraight, LargeStraight,
        Yathzee, Chance, Total
    };

    public partial class Form1 : Form
    {
        UpperScoreSection upperSection;
        Dictionary<ScoreTypeUpper, int> upperScores;

        LowerScoreSection lowerSection;
        Dictionary<ScoreTypeLower, int> lowerScores;

        Die[] dice;

        int rollRemain;
        CheckBox[] holds;
        CheckBox[] scoreCheckBoxes;
        Label[] scoreLabels;

        public Form1()
        {
            InitializeComponent();

            dice = new Die[5];

            holds = new CheckBox[] { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5 };
            scoreCheckBoxes = new CheckBox[] { 
                checkBox6, checkBox7, checkBox8, checkBox9, checkBox10, checkBox11,
                checkBox12, checkBox13, checkBox14, checkBox15, checkBox16, checkBox17, checkBox18
            };
            scoreLabels = new Label[] {
                label2, label4, label6, label8, label10, label12, label13, label14,
                label18, label20, label22, label24, label26, label28, label30
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < scoreLabels.Length; i++)
            {
                scoreLabels[i].Visible = false;
            }

            for (int i = 0; i < scoreCheckBoxes.Length; i++)
            {
                scoreCheckBoxes[i].Checked = false;
            }

            button1.Text = "Roll dice";

            rollRemain = 3;

            upperSection = new UpperScoreSection();
            upperScores = upperSection.getScores();
            label16.Text = upperScores[ScoreTypeUpper.Total].ToString();

            lowerSection = new LowerScoreSection();
            lowerScores = lowerSection.getScores();
            label32.Text = lowerScores[ScoreTypeLower.Total].ToString();

            newRoll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Roll dice")
            {
                timer1.Start();
                timer2.Start();
                setAllEnabled(false);
                rollRemain--;
                label36.Text = rollRemain.ToString();
            }
            else
            {
                Form1_Load(sender, e);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            PictureBox[] pictureBoxes = new PictureBox[5] { pictureBox1, pictureBox2, pictureBox3,
                pictureBox4, pictureBox5 };

            DiceGenerator generator = new DiceGenerator();
            for (int i = 0; i < dice.Length; i++)
            {
                if (!holds[i].Checked)
                {
                    dice[i] = generator.generateDice();
                    pictureBoxes[i].Image = dice[i].Image;
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
            if (areAllCheckBoxesChecked())
            {
                rollRemain = 0;
                button1.Text = "New game";
            }
            else
            {
                rollRemain = 3;
            }
            button1.Enabled = true;
            label36.Text = rollRemain.ToString();

            for (int i = 0; i < holds.Length; i++)
            {
                holds[i].Checked = false;
            }
            label34.Text = (upperScores[ScoreTypeUpper.Total] + lowerScores[ScoreTypeLower.Total]).ToString();
        }

        private bool areAllCheckBoxesChecked()
        {
            for (int i = 0; i < scoreCheckBoxes.Length; i++)
            {
                if (!scoreCheckBoxes[i].Checked)
                {
                    return false;
                }
            }
            return true;
        }

        private void setButtonAndHoldsEnabled(bool isEnabled)
        {
            button1.Enabled = isEnabled;

            for (int i = 0; i < holds.Length; i++)
            {
                holds[i].Enabled = isEnabled;
            }
        }

        private void setAllEnabled(bool isEnabled)
        {
            if (rollRemain == 0)
            {
                setButtonAndHoldsEnabled(false);
            }
            else
            {
                setButtonAndHoldsEnabled(isEnabled);
            }

            for (int i = 0; i < scoreCheckBoxes.Length; i++)
            {
                if (scoreCheckBoxes[i].Checked)
                {
                    scoreCheckBoxes[i].Enabled = false;
                }
                else
                {
                    scoreCheckBoxes[i].Enabled = isEnabled;
                }
            }
        }

        private void checkBoxUpperSection_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox currentCheckBox = (CheckBox)sender;
            if (currentCheckBox.Checked)
            {
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

                upperSection.checkScore(dice, checkedValue);

                currentLabel.Text = upperScores[scoreType].ToString();
                currentLabel.Visible = true;

                if (upperSection.areAllSet())
                {
                    label13.Visible = true;
                    label14.Visible = true;
                    label14.Text = upperScores[ScoreTypeUpper.Bonus].ToString();
                }

                label16.Text = upperScores[ScoreTypeUpper.Total].ToString();

                newRoll();
            }
        }

        private void checkBoxLowerSection_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox currentCheckBox = (CheckBox)sender;
            if (currentCheckBox.Checked)
            {
                Label currentLabel = null;
                ScoreTypeLower scoreType = ScoreTypeLower.Total;
                switch (currentCheckBox.Name)
                {
                    case "checkBox12":
                        scoreType = ScoreTypeLower.ThreeOfKind;
                        currentLabel = label18;
                        break;
                    case "checkBox13":
                        scoreType = ScoreTypeLower.FourOfKind;
                        currentLabel = label20;
                        break;
                    case "checkBox14":
                        scoreType = ScoreTypeLower.FullHouse;
                        currentLabel = label22;
                        break;
                    case "checkBox15":
                        scoreType = ScoreTypeLower.SmallStraight;
                        currentLabel = label24;
                        break;
                    case "checkBox16":
                        scoreType = ScoreTypeLower.LargeStraight;
                        currentLabel = label26;
                        break;
                    case "checkBox17":
                        scoreType = ScoreTypeLower.Yathzee;
                        currentLabel = label28;
                        break;
                    case "checkBox18":
                        scoreType = ScoreTypeLower.Chance;
                        currentLabel = label30;
                        break;
                    default:
                        break;
                }
                lowerSection.checkScore(dice, scoreType);

                currentLabel.Text = lowerScores[scoreType].ToString();
                currentLabel.Visible = true;

                label32.Text = lowerScores[ScoreTypeLower.Total].ToString();

                newRoll();
            }
        }
    }
}
