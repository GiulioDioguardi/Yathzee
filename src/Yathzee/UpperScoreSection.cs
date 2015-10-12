﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yathzee
{
    public class UpperScoreSection : ScoreSection
    {
        private Dictionary<string, int> scoreValues = new Dictionary<string, int>();
        private bool oneIsSet = false, twoIsSet = false, threeIsSet = false,
            fourIsSet = false, fiveIsSet = false, sixIsSet = false, isInitialized = false;

        private void initializeScoreValues()
        {
            scoreValues.Add("one", 0);
            scoreValues.Add("two", 0);
            scoreValues.Add("three", 0);
            scoreValues.Add("four", 0);
            scoreValues.Add("five", 0);
            scoreValues.Add("six", 0);
            scoreValues.Add("bonus", 0);
            scoreValues.Add("total", getTotal());
        }

        public Dictionary<string, int> checkScore(Die[] dice, int checkedValue)
        {
            if (!isInitialized)
            {
                initializeScoreValues();
                isInitialized = true;
            }

            int[] diceValues = new int[5];
            for (int i = 0; i < dice.Length; i++)
            {
                diceValues[i] = dice[i].getDieValue();
            }
            switch (checkedValue)
            {
                case 1:
                    scoreValues["one"] = sumScore(diceValues, checkedValue);
                    oneIsSet = true;
                    break;
                case 2:
                    scoreValues["two"] = sumScore(diceValues, checkedValue);
                    twoIsSet = true;
                    break;
                case 3:
                    scoreValues["three"] = sumScore(diceValues, checkedValue);
                    threeIsSet = true;
                    break;
                case 4:
                    scoreValues["four"] = sumScore(diceValues, checkedValue);
                    fourIsSet = true;
                    break;
                case 5:
                    scoreValues["five"] = sumScore(diceValues, checkedValue);
                    fiveIsSet = true;
                    break;
                case 6:
                    scoreValues["six"] = sumScore(diceValues, checkedValue);
                    sixIsSet = true;
                    break;
                default:
                    break;
            }

            if (areAllSet())
            {
                scoreValues["bonus"] = 0;
                if (isBonusEarned())
                {
                    scoreValues["bonus"] = 35;
                }
            }

            setTotal(sumTotal());
            scoreValues["total"] = getTotal();
            return scoreValues;
        }

        private bool isBonusEarned()
        {
            int sum = scoreValues["one"] + scoreValues["two"] + scoreValues["three"] +
                scoreValues["four"] + scoreValues["five"] + scoreValues["six"];
            if (sum >= 63)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool areAllSet()
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
            return scoreValues["one"] + scoreValues["two"] + scoreValues["three"] +
                scoreValues["four"] + scoreValues["five"] + scoreValues["six"] +
                scoreValues["bonus"];
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