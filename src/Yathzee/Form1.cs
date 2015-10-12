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
    public enum ScoreTypeUpper { One, Two, Three, Four, Five, Six, Bonus, Total };
    public enum ScoreTypeLower { ThreeOfKind, FourOfKind, FullHouse, SmallStraight, LargeStraight,
                          Yathzee, Chance, Total };
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Die[] dice = new Die[5];
            DiceGenerator generator = new DiceGenerator();
            for (int i = 0; i < dice.Length; i++)
            {
                dice[i] = generator.generateDice();
            }
            
            for (int i = 0; i < dice.Length; i++)
            {
                Console.WriteLine(dice[i].getDieValue());
                Console.WriteLine(dice[i].getDieImage());
            }
        }
    }
}
