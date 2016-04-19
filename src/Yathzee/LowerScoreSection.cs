using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yathzee
{
    /// <summary>
    /// Class responsible to hold the data for the lower score section and test the Die values for 
    /// specific scores.
    /// </summary>
    public class LowerScoreSection : ScoreSection
    {
        /// <summary>
        /// Data holder for score values.
        /// </summary>
        private Dictionary<ScoreTypeLower, int> scoreValues = new Dictionary<ScoreTypeLower, int>();

        public LowerScoreSection()
        {
            initializeScoreValues();
        }

        private void initializeScoreValues()
        {
            scoreValues.Add(ScoreTypeLower.ThreeOfKind, 0);
            scoreValues.Add(ScoreTypeLower.FourOfKind, 0);
            scoreValues.Add(ScoreTypeLower.FullHouse, 0);
            scoreValues.Add(ScoreTypeLower.SmallStraight, 0);
            scoreValues.Add(ScoreTypeLower.LargeStraight, 0);
            scoreValues.Add(ScoreTypeLower.Yathzee, 0);
            scoreValues.Add(ScoreTypeLower.Chance, 0);
            scoreValues.Add(ScoreTypeLower.Total, Total);
        }

        public Dictionary<ScoreTypeLower, int> getScores()
        {
            return scoreValues;
        }

        /// <summary>
        /// Main entry point for the class. Checkes what the score is for a
        /// dice array with a score type, and stores it in the scoreValues Dictonary.
        /// </summary>
        /// <param name="dice"></param>
        /// <param name="scoreType"></param>
        public void checkScore(Die[] dice, ScoreTypeLower scoreType)
        {
            int[] diceValues = new int[5];
            for (int i = 0; i < dice.Length; i++)
            {
                diceValues[i] = dice[i].Value;
            }

            Array.Sort(diceValues);

            switch (scoreType)
            {
                case ScoreTypeLower.ThreeOfKind:
                    scoreValues[scoreType] = checkForThreeOfKind(diceValues);
                    break;
                case ScoreTypeLower.FourOfKind:
                    scoreValues[scoreType] = checkForFourOfKind(diceValues);
                    break;
                case ScoreTypeLower.FullHouse:
                    scoreValues[scoreType] = checkForFullHouse(diceValues);
                    break;
                case ScoreTypeLower.SmallStraight:
                    scoreValues[scoreType] = checkForSmallStraight(diceValues);
                    break;
                case ScoreTypeLower.LargeStraight:
                    scoreValues[scoreType] = checkForLargeStraight(diceValues);
                    break;
                case ScoreTypeLower.Yathzee:
                    scoreValues[scoreType] = checkForYathzee(diceValues);
                    break;
                case ScoreTypeLower.Chance:
                    scoreValues[scoreType] = checkForChance(diceValues);
                    break;
                default:
                    break;
            }

            Total = sumTotal();
            scoreValues[ScoreTypeLower.Total] = Total;
        }

        /// <summary>
        /// Sums up the integer values.
        /// </summary>
        /// <param name="values">The integers to be summed.</param>
        /// <returns>The sum.</returns>
        private int sumValues(int[] values)
        {
            int sum = 0;
            for (int i = 0; i < values.Length; i++)
            {
                sum += values[i];
            }
            return sum;
        }

        /// <summary>
        /// Checks if the array of integers is fit to be counted as Three of Kind.
        /// A Three of Kind is valid if 3 or more dice have the same value. If they are,
        /// the score is the sum of the dice values. If not, it is 0.
        /// </summary>
        /// <param name="diceValues">The array of dice values</param>
        /// <returns>The outcome of the test</returns>
        private int checkForThreeOfKind(int[] diceValues)
        {
            if ((diceValues[0] == diceValues[1] && diceValues[0] == diceValues[2]) ||
                 (diceValues[1] == diceValues[2] && diceValues[1] == diceValues[3]) ||
                 (diceValues[2] == diceValues[3] && diceValues[2] == diceValues[4]))
            {
                return sumValues(diceValues);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Checks if the array of integers is fit to be counted as Four of Kind.
        /// A Four of Kind is valid if 4 or more dice have the same value. If they are,
        /// the score is the sum of the dice values. If not, it is 0.
        /// </summary>
        /// <param name="diceValues">The array of dice values</param>
        /// <returns>The outcome of the test</returns>
        private int checkForFourOfKind(int[] diceValues)
        {
            if ((diceValues[0] == diceValues[1] && diceValues[0] == diceValues[2] &&
                  diceValues[0] == diceValues[3]) ||
                 (diceValues[1] == diceValues[2] && diceValues[1] == diceValues[3] &&
                  diceValues[1] == diceValues[4]))
            {
                return sumValues(diceValues);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Checks if the array of integers is fit to be counted as Full House.
        /// A Full House is valid if there are 2 and 3 dice of the same value.
        /// If they are, the score is 25. If not, it is 0.
        /// </summary>
        /// <param name="diceValues">The array of dice values</param>
        /// <returns>The outcome of the test</returns>
        private int checkForFullHouse(int[] diceValues)
        {
            if ((diceValues[0] == diceValues[1] && diceValues[0] == diceValues[2] &&
                 diceValues[3] == diceValues[4]) ||
                (diceValues[0] == diceValues[1] &&
                 diceValues[2] == diceValues[3] && diceValues[2] == diceValues[4]))
            {
                return 25;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Checks if the array of integers is fit to be counted as Small Straight.
        /// A Small Straight is valid if there are 4 or more ascending dice values.
        /// If they are, the score is 30. If not, it is 0.
        /// </summary>
        /// <param name="diceValues">The array of dice values</param>
        /// <returns>The outcome of the test</returns>
        private int checkForSmallStraight(int[] diceValues)
        {
            if ((diceValues[0] == diceValues[1] - 1 && diceValues[1] == diceValues[2] - 1 &&
                diceValues[2] == diceValues[3] - 1) ||
                (diceValues[0] == diceValues[1] - 1 && diceValues[1] == diceValues[2] - 1 &&
                diceValues[2] == diceValues[4] - 1) ||
                (diceValues[0] == diceValues[1] - 1 && diceValues[1] == diceValues[3] - 1 &&
                diceValues[3] == diceValues[4] - 1) ||
                (diceValues[0] == diceValues[2] - 1 && diceValues[2] == diceValues[3] - 1 &&
                diceValues[3] == diceValues[4] - 1) ||
                (diceValues[1] == diceValues[2] - 1 && diceValues[2] == diceValues[3] - 1 &&
                diceValues[3] == diceValues[4] - 1))
            {
                return 30;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Checks if the array of integers is fit to be counted as Large Straight.
        /// A Large Straight is valid if there are 5 ascending dice values.
        /// If they are, the score is 40. If not, it is 0.
        /// </summary>
        /// <param name="diceValues">The array of dice values</param>
        /// <returns>The outcome of the test</returns>
        private int checkForLargeStraight(int[] diceValues)
        {
            if ((diceValues[0] == diceValues[1] - 1 && diceValues[1] == diceValues[2] - 1 &&
                diceValues[2] == diceValues[3] - 1 && diceValues[3] == diceValues[4] - 1))
            {
                return 40;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Checks if the array of integers is fit to be counted as Yathzee.
        /// A Yathzee is valid if all dice values are the same.
        /// If they are, the score is 50. If not, it is 0.
        /// </summary>
        /// <param name="diceValues">The array of dice values</param>
        /// <returns>The outcome of the test</returns>
        private int checkForYathzee(int[] diceValues)
        {
            if (diceValues[0] == diceValues[1] && diceValues[0] == diceValues[2] &&
                diceValues[0] == diceValues[3] && diceValues[0] == diceValues[4])
            {
                return 50;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Checks if the array of integers if fit to be counted as Chance.
        /// It will always be fit for Chance.
        /// The score is the sum of the integer values
        /// </summary>
        /// <param name="diceValues">The array of dice values</param>
        /// <returns>The outcome of the test</returns>
        private int checkForChance(int[] diceValues)
        {
            return sumValues(diceValues);
        }

        /// <summary>
        /// Sums the total of the lower score section.
        /// </summary>
        /// <returns>The sum of the lower score section.</returns>
        private int sumTotal()
        {
            return scoreValues[ScoreTypeLower.ThreeOfKind] + 
            scoreValues[ScoreTypeLower.FourOfKind] +
            scoreValues[ScoreTypeLower.FullHouse] + 
            scoreValues[ScoreTypeLower.SmallStraight] +
            scoreValues[ScoreTypeLower.LargeStraight] +
            scoreValues[ScoreTypeLower.Yathzee] +
            scoreValues[ScoreTypeLower.Chance];
        }
    }
}
