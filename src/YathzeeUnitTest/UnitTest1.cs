using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yathzee;

namespace YathzeeUnitTest
{
    [TestClass]
    public class UnitTest1
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
}
