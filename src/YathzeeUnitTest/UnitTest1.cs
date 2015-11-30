using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Yathzee;

namespace Yathzee
{
    [TestClass]
    public class DieTests
    {
        [TestMethod]
        public void DieTest()
        {
            for (int i = 0; i < 6; i++)
            {
                Die die = new Die(i);
                Assert.AreEqual(i, die.Value);
            }
        }

        /*   [TestMethod]
           public void DieImageTest()
           {
               Die die = new Die(0);
               DieImage image = new DieImage();
               System.Drawing.Image expected = image.getDieBlank();
               System.Drawing.Image actual = die.getDieImage();
               Assert.AreEqual(expected, actual);
           }*/

        [TestMethod]
        public void DiceGeneratorTest()
        {
            DiceGenerator generator = new DiceGenerator();
            for (int i = 0; i < 100; i++)
            {
                Die die = generator.generateDice();
                Assert.IsTrue(die.Value <= 6, "Die shows a value too high.");
                Assert.IsTrue(die.Value > 0, "Die shows a value too low.");
            }
        }
    }

    [TestClass]
    public class UpperScoreSectionTest
    {
        [TestMethod]
        public void OneThreeFourTest()
        {
            UpperScoreSection upperSection = new UpperScoreSection();
            Die[] dice = new Die[5] { new Die(3), new Die(1), new Die(1), new Die(4), new Die(6) };
            Dictionary<ScoreTypeUpper, int> upper = new Dictionary<ScoreTypeUpper, int>();
            upperSection.checkScore(dice, 1);
            upper = upperSection.getScores();
            Assert.AreEqual(2, upper[ScoreTypeUpper.One], "Error in ones");
            upperSection.checkScore(dice, 3);
            upper = upperSection.getScores();
            Assert.AreEqual(3, upper[ScoreTypeUpper.Three], "Error in threes");
            upperSection.checkScore(dice, 4);
            upper = upperSection.getScores();
            Assert.AreEqual(4, upper[ScoreTypeUpper.Four], "Error in fours");
        }

        [TestMethod]
        public void ZeroScoreTest()
        {
            UpperScoreSection upperSection = new UpperScoreSection();
            Die[] dice = new Die[5] { new Die(5), new Die(2), new Die(3), new Die(6), new Die(6) };
            Dictionary<ScoreTypeUpper, int> upper = new Dictionary<ScoreTypeUpper, int>();
            upperSection.checkScore(dice, 1);
            upper = upperSection.getScores();
            Assert.AreEqual(0, upper[ScoreTypeUpper.One], "Error in ones, zero score expected");
        }

        [TestMethod]
        public void TotalTestUpper()
        {
            UpperScoreSection upperSection = new UpperScoreSection();
            Dictionary<ScoreTypeUpper, int> scoreValues = new Dictionary<ScoreTypeUpper, int>();
            Die[] dice = new Die[5] { new Die(6), new Die(6), new Die(6), new Die(2), new Die(4) };
            upperSection.checkScore(dice, 6);
            scoreValues = upperSection.getScores();
            Assert.AreEqual(18, scoreValues[ScoreTypeUpper.Total]);
            dice = new Die[5] { new Die(6), new Die(6), new Die(2), new Die(2), new Die(4) };
            upperSection.checkScore(dice, 2);
            scoreValues = upperSection.getScores();
            Assert.AreEqual(22, scoreValues[ScoreTypeUpper.Total]);
        }
        [TestMethod]
        public void BonusTestEarned()
        {
            UpperScoreSection upperSection = new UpperScoreSection();
            Dictionary<ScoreTypeUpper, int> upperBonusEarned = new Dictionary<ScoreTypeUpper, int>();

            Die[] dice = new Die[5] { new Die(1), new Die(1), new Die(1), new Die(2), new Die(4) };
            upperSection.checkScore(dice, 1);
            upperBonusEarned = upperSection.getScores();
            Assert.AreEqual(0, upperBonusEarned[ScoreTypeUpper.Bonus], "Bonus is given when it shouldn't");

            dice = new Die[5] { new Die(2), new Die(6), new Die(2), new Die(2), new Die(4) };
            upperSection.checkScore(dice, 2);
            upperBonusEarned = upperSection.getScores();
            Assert.AreEqual(0, upperBonusEarned[ScoreTypeUpper.Bonus], "Bonus is given when it shouldn't");

            dice = new Die[5] { new Die(3), new Die(3), new Die(6), new Die(3), new Die(4) };
            upperSection.checkScore(dice, 3);
            upperBonusEarned = upperSection.getScores();
            Assert.AreEqual(0, upperBonusEarned[ScoreTypeUpper.Bonus], "Bonus is given when it shouldn't");

            dice = new Die[5] { new Die(4), new Die(5), new Die(4), new Die(2), new Die(4) };
            upperSection.checkScore(dice, 4);
            upperBonusEarned = upperSection.getScores();
            Assert.AreEqual(0, upperBonusEarned[ScoreTypeUpper.Bonus], "Bonus is given when it shouldn't");

            dice = new Die[5] { new Die(6), new Die(5), new Die(6), new Die(5), new Die(5) };
            upperSection.checkScore(dice, 5);
            upperBonusEarned = upperSection.getScores();
            Assert.AreEqual(0, upperBonusEarned[ScoreTypeUpper.Bonus], "Bonus is given when it shouldn't");

            Assert.AreEqual(45, upperBonusEarned[ScoreTypeUpper.Total], "Bonus is not given when it should");
            dice = new Die[5] { new Die(6), new Die(6), new Die(6), new Die(2), new Die(4) };
            upperSection.checkScore(dice, 6);
            upperBonusEarned = upperSection.getScores();

            Assert.AreEqual(35, upperBonusEarned[ScoreTypeUpper.Bonus], "Bonus is not given when it should");
        }

        [TestMethod]
        public void BonusTestNotEarned()
        {
            UpperScoreSection upperSection = new UpperScoreSection();
            Dictionary<ScoreTypeUpper, int> upperBonusNotEarned = new Dictionary<ScoreTypeUpper, int>();

            Die[] dice = new Die[5] { new Die(1), new Die(2), new Die(1), new Die(2), new Die(4) };
            upperSection.checkScore(dice, 1);
            upperBonusNotEarned = upperSection.getScores();
            Assert.AreEqual(2, upperBonusNotEarned[ScoreTypeUpper.Total], "Bonus is given when it shouldn't");

            dice = new Die[5] { new Die(2), new Die(6), new Die(1), new Die(2), new Die(4) };
            upperSection.checkScore(dice, 2);
            upperBonusNotEarned = upperSection.getScores();
            Assert.AreEqual(6, upperBonusNotEarned[ScoreTypeUpper.Total], "Bonus is given when it shouldn't");

            dice = new Die[5] { new Die(3), new Die(4), new Die(6), new Die(3), new Die(4) };
            upperSection.checkScore(dice, 3);
            upperBonusNotEarned = upperSection.getScores();
            Assert.AreEqual(12, upperBonusNotEarned[ScoreTypeUpper.Total], "Bonus is given when it shouldn't");

            dice = new Die[5] { new Die(4), new Die(5), new Die(4), new Die(2), new Die(4) };
            upperSection.checkScore(dice, 4);
            upperBonusNotEarned = upperSection.getScores();
            Assert.AreEqual(24, upperBonusNotEarned[ScoreTypeUpper.Total], "Bonus is given when it shouldn't");

            dice = new Die[5] { new Die(6), new Die(5), new Die(6), new Die(5), new Die(5) };
            upperSection.checkScore(dice, 5);
            upperBonusNotEarned = upperSection.getScores();
            Assert.AreEqual(39, upperBonusNotEarned[ScoreTypeUpper.Total], "Bonus is given when it shouldn't");

            dice = new Die[5] { new Die(6), new Die(5), new Die(6), new Die(2), new Die(4) };
            upperSection.checkScore(dice, 6);
            upperBonusNotEarned = upperSection.getScores();
            Assert.AreEqual(51, upperBonusNotEarned[ScoreTypeUpper.Total], "Bonus is given when it shouldn't");
            Assert.AreEqual(0, upperBonusNotEarned[ScoreTypeUpper.Bonus], "Bonus is given when it shouldn't");
        }
    }
    [TestClass]
    public class LowerScoreSectionTest
    {
        [TestMethod]
        public void ThreeOfKindTest()
        {
            LowerScoreSection lowerSection = new LowerScoreSection();
            Dictionary<ScoreTypeLower, int> threeOfKind = new Dictionary<ScoreTypeLower, int>();

            Die[] dice = new Die[5] { new Die(1), new Die(1), new Die(1), new Die(2), new Die(4) };
            lowerSection.checkScore(dice, ScoreTypeLower.ThreeOfKind);
            threeOfKind = lowerSection.getScores();
            Assert.AreEqual(9, threeOfKind[ScoreTypeLower.ThreeOfKind]);

            dice = new Die[5] { new Die(4), new Die(2), new Die(1), new Die(2), new Die(2) };
            lowerSection.checkScore(dice, ScoreTypeLower.ThreeOfKind);
            threeOfKind = lowerSection.getScores();
            Assert.AreEqual(11, threeOfKind[ScoreTypeLower.ThreeOfKind]);

            dice = new Die[5] { new Die(6), new Die(5), new Die(6), new Die(6), new Die(2) };
            lowerSection.checkScore(dice, ScoreTypeLower.ThreeOfKind);
            threeOfKind = lowerSection.getScores();
            Assert.AreEqual(25, threeOfKind[ScoreTypeLower.ThreeOfKind]);

            dice = new Die[5] { new Die(1), new Die(3), new Die(1), new Die(2), new Die(4) };
            lowerSection.checkScore(dice, ScoreTypeLower.ThreeOfKind);
            threeOfKind = lowerSection.getScores();
            Assert.AreEqual(0, threeOfKind[ScoreTypeLower.ThreeOfKind]);
        }

        [TestMethod]
        public void FourOfKindTest()
        {
            LowerScoreSection lowerSection = new LowerScoreSection();
            Dictionary<ScoreTypeLower, int> fourOfKind = new Dictionary<ScoreTypeLower, int>();

            Die[] dice = new Die[5] { new Die(1), new Die(1), new Die(1), new Die(1), new Die(4) };
            lowerSection.checkScore(dice, ScoreTypeLower.FourOfKind);
            fourOfKind = lowerSection.getScores();
            Assert.AreEqual(8, fourOfKind[ScoreTypeLower.FourOfKind]);

            dice = new Die[5] { new Die(3), new Die(4), new Die(4), new Die(4), new Die(4) };
            lowerSection.checkScore(dice, ScoreTypeLower.FourOfKind);
            fourOfKind = lowerSection.getScores();
            Assert.AreEqual(19, fourOfKind[ScoreTypeLower.FourOfKind]);

            dice = new Die[5] { new Die(1), new Die(3), new Die(1), new Die(2), new Die(4) };
            lowerSection.checkScore(dice, ScoreTypeLower.FourOfKind);
            fourOfKind = lowerSection.getScores();
            Assert.AreEqual(0, fourOfKind[ScoreTypeLower.FourOfKind]);
        }
        [TestMethod]
        public void FullHouseTest()
        {
            LowerScoreSection lowerSection = new LowerScoreSection();
            Dictionary<ScoreTypeLower, int> fullHouse = new Dictionary<ScoreTypeLower, int>();

            Die[] dice = new Die[5] { new Die(1), new Die(1), new Die(1), new Die(2), new Die(2) };
            lowerSection.checkScore(dice, ScoreTypeLower.FullHouse);
            fullHouse = lowerSection.getScores();
            Assert.AreEqual(25, fullHouse[ScoreTypeLower.FullHouse]);

            dice = new Die[5] { new Die(3), new Die(3), new Die(3), new Die(2), new Die(2) };
            lowerSection.checkScore(dice, ScoreTypeLower.FullHouse);
            fullHouse = lowerSection.getScores();
            Assert.AreEqual(25, fullHouse[ScoreTypeLower.FullHouse]);

            dice = new Die[5] { new Die(1), new Die(5), new Die(1), new Die(4), new Die(2) };
            lowerSection.checkScore(dice, ScoreTypeLower.FullHouse);
            fullHouse = lowerSection.getScores();
            Assert.AreEqual(0, fullHouse[ScoreTypeLower.FullHouse]);
        }

        [TestMethod]
        public void SmallStraightTest()
        {
            LowerScoreSection lowerSection = new LowerScoreSection();
            Dictionary<ScoreTypeLower, int> smallStraight = new Dictionary<ScoreTypeLower, int>();

            Die[] dice = new Die[5] { new Die(1), new Die(2), new Die(3), new Die(4), new Die(6) };
            lowerSection.checkScore(dice, ScoreTypeLower.SmallStraight);
            smallStraight = lowerSection.getScores();
            Assert.AreEqual(30, smallStraight[ScoreTypeLower.SmallStraight]);

            dice = new Die[5] { new Die(2), new Die(3), new Die(4), new Die(4), new Die(5) };
            lowerSection.checkScore(dice, ScoreTypeLower.SmallStraight);
            smallStraight = lowerSection.getScores();
            Assert.AreEqual(30, smallStraight[ScoreTypeLower.SmallStraight]);

            dice = new Die[5] { new Die(1), new Die(2), new Die(2), new Die(3), new Die(4) };
            lowerSection.checkScore(dice, ScoreTypeLower.SmallStraight);
            smallStraight = lowerSection.getScores();
            Assert.AreEqual(30, smallStraight[ScoreTypeLower.SmallStraight]);

            dice = new Die[5] { new Die(2), new Die(2), new Die(3), new Die(4), new Die(5) };
            lowerSection.checkScore(dice, ScoreTypeLower.SmallStraight);
            smallStraight = lowerSection.getScores();
            Assert.AreEqual(30, smallStraight[ScoreTypeLower.SmallStraight]);

            dice = new Die[5] { new Die(1), new Die(2), new Die(3), new Die(4), new Die(5) };
            lowerSection.checkScore(dice, ScoreTypeLower.SmallStraight);
            smallStraight = lowerSection.getScores();
            Assert.AreEqual(30, smallStraight[ScoreTypeLower.SmallStraight]);

            dice = new Die[5] { new Die(1), new Die(1), new Die(3), new Die(4), new Die(6) };
            lowerSection.checkScore(dice, ScoreTypeLower.SmallStraight);
            smallStraight = lowerSection.getScores();
            Assert.AreEqual(0, smallStraight[ScoreTypeLower.SmallStraight]);
        }

        [TestMethod]
        public void LargeStraightTest()
        {
            LowerScoreSection lowerSection = new LowerScoreSection();
            Dictionary<ScoreTypeLower, int> largeStraight = new Dictionary<ScoreTypeLower, int>();

            Die[] dice = new Die[5] { new Die(1), new Die(2), new Die(3), new Die(4), new Die(5) };
            lowerSection.checkScore(dice, ScoreTypeLower.LargeStraight);
            largeStraight = lowerSection.getScores();
            Assert.AreEqual(40, largeStraight[ScoreTypeLower.LargeStraight]);

            dice = new Die[5] { new Die(6), new Die(2), new Die(3), new Die(4), new Die(5) };
            lowerSection.checkScore(dice, ScoreTypeLower.LargeStraight);
            largeStraight = lowerSection.getScores();
            Assert.AreEqual(40, largeStraight[ScoreTypeLower.LargeStraight]);

            dice = new Die[5] { new Die(1), new Die(2), new Die(4), new Die(4), new Die(5) };
            lowerSection.checkScore(dice, ScoreTypeLower.LargeStraight);
            largeStraight = lowerSection.getScores();
            Assert.AreEqual(0, largeStraight[ScoreTypeLower.LargeStraight]);
        }

        [TestMethod]
        public void YathzeeTest()
        {
            LowerScoreSection lowerSection = new LowerScoreSection();
            Dictionary<ScoreTypeLower, int> yathzee = new Dictionary<ScoreTypeLower, int>();

            Die[] dice = new Die[5] { new Die(2), new Die(2), new Die(2), new Die(2), new Die(2) };
            lowerSection.checkScore(dice, ScoreTypeLower.Yathzee);
            yathzee = lowerSection.getScores();
            Assert.AreEqual(50, yathzee[ScoreTypeLower.Yathzee]);

            dice = new Die[5] { new Die(2), new Die(3), new Die(2), new Die(2), new Die(2) };
            lowerSection.checkScore(dice, ScoreTypeLower.Yathzee);
            yathzee = lowerSection.getScores();
            Assert.AreEqual(0, yathzee[ScoreTypeLower.Yathzee]);
        }

        [TestMethod]
        public void TotalTestLower()
        {
            LowerScoreSection lowerSection = new LowerScoreSection();
            Dictionary<ScoreTypeLower, int> scoreValues = new Dictionary<ScoreTypeLower, int>();
            Die[] dice = new Die[5] { new Die(6), new Die(3), new Die(6), new Die(2), new Die(4) };

            lowerSection.checkScore(dice, ScoreTypeLower.Chance);
            scoreValues = lowerSection.getScores();
            Assert.AreEqual(21, scoreValues[ScoreTypeLower.Total]);

            dice = new Die[5] { new Die(6), new Die(6), new Die(6), new Die(6), new Die(4) };
            lowerSection.checkScore(dice, ScoreTypeLower.FourOfKind);
            scoreValues = lowerSection.getScores();
            Assert.AreEqual(49, scoreValues[ScoreTypeLower.Total]);
        }

    }
}
