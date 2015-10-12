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
        public void OneTest()
        {
            UpperScoreSection upperSection = new UpperScoreSection();
            Die[] dice = new Die[5] { new Die(3), new Die(1), new Die(1), new Die(4), new Die(6) };
            Dictionary<string, int> one = new Dictionary<string, int>();
            one = upperSection.checkScore(dice, 1);
            Assert.AreEqual(2, one["one"], "Error in ones");
            Dictionary<string, int> three = new Dictionary<string, int>();
            three = upperSection.checkScore(dice, 3);
            Assert.AreEqual(3, three["three"], "Error in threes");
        }
    }
}
