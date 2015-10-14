using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yathzee
{
    public class UpperScoreSection : ScoreSection
    {
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
            scoreValues.Add(ScoreTypeUpper.Total, getTotal());
        }

        public Dictionary<ScoreTypeUpper, int> getScores()
        {
            return scoreValues;
        }

        public void checkScore(Die[] dice, int checkedValue)
        {
            int[] diceValues = new int[5];
            for (int i = 0; i < dice.Length; i++)
            {
                diceValues[i] = dice[i].getDieValue();
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

            setTotal(sumTotal());
            scoreValues[ScoreTypeUpper.Total] = getTotal();
        }

        private bool isBonusEarned()
        {
            int sum = scoreValues[ScoreTypeUpper.One] + scoreValues[ScoreTypeUpper.Two] +
                scoreValues[ScoreTypeUpper.Three] + scoreValues[ScoreTypeUpper.Four] +
                scoreValues[ScoreTypeUpper.Five] + scoreValues[ScoreTypeUpper.Six];

            if (sum >= 63)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool areAllSet()
        {
            if (oneIsSet && twoIsSet && threeIsSet && fourIsSet && fiveIsSet && sixIsSet)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int sumTotal()
        {
            return scoreValues[ScoreTypeUpper.One] + scoreValues[ScoreTypeUpper.Two] +
                scoreValues[ScoreTypeUpper.Three] + scoreValues[ScoreTypeUpper.Four] +
                scoreValues[ScoreTypeUpper.Five] + scoreValues[ScoreTypeUpper.Six] +
                scoreValues[ScoreTypeUpper.Bonus];
        }

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
