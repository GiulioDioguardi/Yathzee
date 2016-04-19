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
    /// <summary>
    /// Score type for the upper part of the score section.
    /// </summary>
    public enum ScoreTypeUpper : byte
    {
        One, Two, Three, Four, Five, Six, Bonus, Total
    };

    /// <summary>
    /// Score type for the lower part of the score section.
    /// </summary>
    public enum ScoreTypeLower : byte
    {
        ThreeOfKind, FourOfKind, FullHouse, SmallStraight, LargeStraight,
        Yathzee, Chance, Total
    };

    /// <summary>
    /// The Graphical User Interface for Yathzee.
    /// </summary>
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

        /// <summary>
        /// Sets up the GUI.
        /// </summary>
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

        /// <summary>
        /// Handles the click event on button1. During the game, the button will 
        /// let the dice roll. At the end of the game, the button will act as a
        /// reset button to start the game over.
        /// </summary>
        /// <param name="sender">Button object that has sent the event.</param>
        /// <param name="e">Varable containing event data.</param>
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

        /// <summary>
        /// Generates a set of Die objects every time the timer ticks, except when
        /// the associating hold check box is checked. Updates the GUI for each 
        /// tick.
        /// </summary>
        /// <param name="sender">Object that has sent the tick.</param>
        /// <param name="e">Varable containing event data.</param>
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

        /// <summary>
        /// Stops the dice rolling.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            setAllEnabled(true);
        }

        /// <summary>
        /// Void function that resets the state of the form after a roll.
        /// Should always be called after a score checkbox has been checked.
        /// </summary>
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

        /// <summary>
        /// Checks whether all score checkboxes have been checked
        /// </summary>
        /// <returns>The result of the test</returns>
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

        /// <summary>
        /// Set all buttons and hold checkboxes to a enabled or disabled state.
        /// </summary>
        /// <param name="isEnabled">The state to be set</param>
        private void setButtonAndHoldsEnabled(bool isEnabled)
        {
            button1.Enabled = isEnabled;

            for (int i = 0; i < holds.Length; i++)
            {
                holds[i].Enabled = isEnabled;
            }
        }

        /// <summary>
        /// Set all inputs of the form to the desired enabled state. If no rolls are left, put the hold checkboxes on disabled state.
        /// </summary>
        /// <param name="isEnabled">The state to be set</param>
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

        /// <summary>
        /// Handles the event when a checkbox has been checked or unchecked in the upper score section.
        /// </summary>
        /// <param name="sender">The checkbox that has sent the event.</param>
        /// <param name="e">Variable that contains the event data.</param>
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

        /// <summary>
        /// Handles the event when a checkbox has been checked or unchecked in the lower score section.
        /// </summary>
        /// <param name="sender">The checkbox that has sent the event.</param>
        /// <param name="e">Variable that contains the event data.</param>
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
