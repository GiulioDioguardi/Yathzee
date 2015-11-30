﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yathzee
{
    public class LowerScoreSection : ScoreSection
    {

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

        private int sumValues(int[] values)
        {
            int sum = 0;
            for (int i = 0; i < values.Length; i++)
            {
                sum += values[i];
            }
            return sum;
        }

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

        private int checkForChance(int[] diceValues)
        {
            return sumValues(diceValues);
        }

        private int sumTotal()
        {
            return scoreValues[ScoreTypeLower.ThreeOfKind] + scoreValues[ScoreTypeLower.FourOfKind] +
            scoreValues[ScoreTypeLower.FullHouse] + scoreValues[ScoreTypeLower.SmallStraight] +
            scoreValues[ScoreTypeLower.LargeStraight] +
            scoreValues[ScoreTypeLower.Yathzee] +
            scoreValues[ScoreTypeLower.Chance];
        }
    }
}
