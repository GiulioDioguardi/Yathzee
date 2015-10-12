using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yathzee
{
    public class LowerScoreSection : ScoreSection
    {
        private Dictionary<string, int> scoreValues = new Dictionary<string, int>();
        private bool threeOfKindIsSet = false, fourOfKindIsSet = false, fullHouseIsSet = false,
            smallStraightIsSet = false, largeStraightIsSet = false, yathzeeIsSet = false,
            chanceIsSet = false, isInitialized = false;

        private void initializeScoreValues()
        {
            scoreValues.Add("ThreeOfKind", 0);
            scoreValues.Add("FourOfKind", 0);
            scoreValues.Add("FullHouse", 0);
            scoreValues.Add("SmallStraight", 0);
            scoreValues.Add("LargeStraight", 0);
            scoreValues.Add("Yathzee", 0);
            scoreValues.Add("Chance", 0);
            scoreValues.Add("total", getTotal());
        }

        public Dictionary<string, int> checkScore(Die[] dice, string scoreType)
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

            Array.Sort(diceValues);

            switch (scoreType)
            {
                case "ThreeOfKind":
                    scoreValues[scoreType] = checkForThreeOfKind(diceValues);
                    threeOfKindIsSet = true;
                    break;
                default:
                    break;
            }
            return scoreValues;
        }

        private int checkForThreeOfKind(int[] diceValues)
        {
            if ( (diceValues[0] == diceValues[1] && diceValues[0] == diceValues[2]) ||
                 (diceValues[1] == diceValues[2] && diceValues[1] == diceValues[3]) ||
                 (diceValues[2] == diceValues[3] && diceValues[2] == diceValues[4])  )
            {
                int sum = 0;
                for (int i = 0; i < diceValues.Length; i++)
                {
                    sum += diceValues[i];
                }
                return sum;
            }
            else
            {
                return 0;
            }
        }
    }
}
