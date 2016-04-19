using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yathzee
{
    /// <summary>
    /// Class responsible to hold the data for the upper score section and test the Die values for 
    /// specific scores.
    /// </summary>
    public class UpperScoreSection : ScoreSection
    {
        /// <summary>
        /// Data holder for score values.
        /// </summary>
        private Dictionary<ScoreTypeUpper, int> scoreValues = new Dictionary<ScoreTypeUpper, int>();
        private bool oneIsSet = false, twoIsSet = false, threeIsSet = false,
            fourIsSet = false, fiveIsSet = false, sixIsSet = false;

        public UpperScoreSection()
        {
            initializeScoreValues();
        }
        private void initializeScoreValues()
        {
            scoreValues.Add(ScoreTypeUpper.One, 0);
            scoreValues.Add(ScoreTypeUpper.Two, 0);
            scoreValues.Add(ScoreTypeUpper.Three, 0);
            scoreValues.Add(ScoreTypeUpper.Four, 0);
            scoreValues.Add(ScoreTypeUpper.Five, 0);
            scoreValues.Add(ScoreTypeUpper.Six, 0);
            scoreValues.Add(ScoreTypeUpper.Bonus, 0);
            scoreValues.Add(ScoreTypeUpper.Total, Total);
        }

        public Dictionary<ScoreTypeUpper, int> getScores()
        {
            return scoreValues;
        }

        /// <summary>
        /// Main entry point for the class. Checkes what the score is for a
        /// dice array with a score type, and stores it in the scoreValues Dictonary.
        /// </summary>
        /// <param name="dice">The array of Die objects to check</param>
        /// <param name="scoreType">The score type to check against.</param>
        public void checkScore(Die[] dice, int checkedValue)
        {
            int[] diceValues = new int[5];
            for (int i = 0; i < dice.Length; i++)
            {
                diceValues[i] = dice[i].Value;
            }
            switch (checkedValue)
            {
                case 1:
                    scoreValues[ScoreTypeUpper.One] = sumScore(diceValues, checkedValue);
                    oneIsSet = true;
                    break;
                case 2:
                    scoreValues[ScoreTypeUpper.Two] = sumScore(diceValues, checkedValue);
                    twoIsSet = true;
                    break;
                case 3:
                    scoreValues[ScoreTypeUpper.Three] = sumScore(diceValues, checkedValue);
                    threeIsSet = true;
                    break;
                case 4:
                    scoreValues[ScoreTypeUpper.Four] = sumScore(diceValues, checkedValue);
                    fourIsSet = true;
                    break;
                case 5:
                    scoreValues[ScoreTypeUpper.Five] = sumScore(diceValues, checkedValue);
                    fiveIsSet = true;
                    break;
                case 6:
                    scoreValues[ScoreTypeUpper.Six] = sumScore(diceValues, checkedValue);
                    sixIsSet = true;
                    break;
                default:
                    break;
            }

            if (areAllSet())
            {
                scoreValues[ScoreTypeUpper.Bonus] = 0;
                if (isBonusEarned())
                {
                    scoreValues[ScoreTypeUpper.Bonus] = 35;
                }
            }

            Total = sumTotal(true);
            scoreValues[ScoreTypeUpper.Total] = Total;
        }

        /// <summary>
        /// Checks if a bonus is earned.
        /// </summary>
        /// <returns>
        /// 35 if it is earned (upper score higher than or equal to 63)
        /// 0 if is is not earned.
        /// </returns>
        private bool isBonusEarned()
        {
            int sum = sumTotal(false);

            if (sum >= 63)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if all scores on the upper section are set.
        /// </summary>
        /// <returns>The result of the test.</returns>
        public bool areAllSet()
        {
            if (oneIsSet && twoIsSet && threeIsSet && fourIsSet && fiveIsSet && sixIsSet)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Sums all scores for the upper section.
        /// </summary>
        /// <param name="includeBonus">Choose to include the bonus part or not.</param>
        /// <returns>The subm of the upper section score</returns>
        private int sumTotal(bool includeBonus)
        {
            int sum = scoreValues[ScoreTypeUpper.One] + scoreValues[ScoreTypeUpper.Two] +
                scoreValues[ScoreTypeUpper.Three] + scoreValues[ScoreTypeUpper.Four] +
                scoreValues[ScoreTypeUpper.Five] + scoreValues[ScoreTypeUpper.Six];
            if (includeBonus)
            {
                sum += scoreValues[ScoreTypeUpper.Bonus];
            }
            return sum;
        }

        /// <summary>
        /// Returns the sum for a specific dice value, and not the rest.
        /// 1, 1, 1, 3, 5 as array with dieValue of 1 will return 3.
        /// </summary>
        /// <param name="diceValues">The array of dice values.</param>
        /// <param name="dieValue">The die value to be summed up.</param>
        /// <returns>The sum</returns>
        private int sumScore(int[] diceValues, int dieValue)
        {
            int sum = 0;
            for (int i = 0; i < diceValues.Length; i++)
            {
                if (diceValues[i] == dieValue)
                {
                    sum += dieValue;
                }
            }
            return sum;
        }
    }
}
