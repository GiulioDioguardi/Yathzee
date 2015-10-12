using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Yathzee;

namespace YathzeeUnitTest
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
                Assert.AreEqual(i, die.getDieValue());
            }
        }

        /*  [TestMethod]
          public void DieImageTest()
          {
              Die die = new Die(0);
              DieImage image = new DieImage();
              Assert.AreEqual(image.getDieBlank(), die.getDieImage());
          }*/

        [TestMethod]
        public void DiceGeneratorTest()
        {
            DiceGenerator generator = new DiceGenerator();
            for (int i = 0; i < 100; i++)
            {
                Die die = generator.generateDice();
                Assert.IsTrue(die.getDieValue() <= 6, "Die shows a value too high.");
                Assert.IsTrue(die.getDieValue() > 0, "Die shows a value too low.");
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
            Dictionary<string, int> upper = new Dictionary<string, int>();
            upper = upperSection.checkScore(dice, 1);
            Assert.AreEqual(2, upper["one"], "Error in ones");
            upper = upperSection.checkScore(dice, 3);
            Assert.AreEqual(3, upper["three"], "Error in threes");
            upper = upperSection.checkScore(dice, 4);
            Assert.AreEqual(4, upper["four"], "Error in fours");
        }

        [TestMethod]
        public void ZeroScoreTest()
        {
            UpperScoreSection upperSection = new UpperScoreSection();
            Die[] dice = new Die[5] { new Die(5), new Die(2), new Die(3), new Die(6), new Die(6) };
            Dictionary<string, int> upper = new Dictionary<string, int>();
            upper = upperSection.checkScore(dice, 1);
            Assert.AreEqual(0, upper["one"], "Error in ones, zero score expected");
        }

        [TestMethod]
        public void TotalTest()
        {

            UpperScoreSection upperSection = new UpperScoreSection();
            Dictionary<string, int> scoreValues = new Dictionary<string, int>();
            Die[] dice = new Die[5] { new Die(6), new Die(6), new Die(6), new Die(2), new Die(4) };
            scoreValues = upperSection.checkScore(dice, 6);
            Assert.AreEqual(18, scoreValues["total"]);
            dice = new Die[5] { new Die(6), new Die(6), new Die(2), new Die(2), new Die(4) };
            scoreValues = upperSection.checkScore(dice, 2);
            Assert.AreEqual(22, scoreValues["total"]);
        }
        [TestMethod]
        public void BonusTest()
        {
            UpperScoreSection upperSection = new UpperScoreSection();
            Dictionary<string, int> upperBonusEarned = new Dictionary<string, int>();

            Die[] dice = new Die[5] { new Die(1), new Die(1), new Die(1), new Die(2), new Die(4) };
            upperBonusEarned = upperSection.checkScore(dice, 1);

            dice = new Die[5] { new Die(2), new Die(6), new Die(2), new Die(2), new Die(4) };
            upperBonusEarned = upperSection.checkScore(dice, 2);

            dice = new Die[5] { new Die(3), new Die(3), new Die(6), new Die(3), new Die(4) };
            upperBonusEarned = upperSection.checkScore(dice, 3);

            dice = new Die[5] { new Die(4), new Die(5), new Die(4), new Die(2), new Die(4) };
            upperBonusEarned = upperSection.checkScore(dice, 4);

            dice = new Die[5] { new Die(6), new Die(5), new Die(6), new Die(5), new Die(5) };
            upperBonusEarned = upperSection.checkScore(dice, 5);

            dice = new Die[5] { new Die(6), new Die(6), new Die(6), new Die(2), new Die(4) };
            upperBonusEarned = upperSection.checkScore(dice, 6);

            Assert.AreEqual(35, upperBonusEarned["bonus"], "Bonus is not given when it should");
        }
    }
}
