using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingTDDNS;

namespace BowlingUnitTest
{
    [TestClass]
    public class BowlingGameTests
    {
        private Game g;

        private void RollStrike()
        {
            g.Roll(10);
        }

        private void RollSpare()
        {
            g.Roll(5);
            g.Roll(5);
        }

        private void RollMany(int rollNum, int pins)
        {
            for (int rollIter = 0; rollIter < rollNum; rollIter++)
                g.Roll(pins);
        }

        [TestInitialize]
        public void SetUp()
        {
            g = new Game();
        }

        [TestMethod]
        public void CanRoll()
        {
            g.Roll(0);
        }

        [TestMethod]
        public void GutterGame()
        {
            RollMany(20, 0);
            Assert.AreEqual(0, g.Score());
        }

        [TestMethod]
        public void AllOnes()
        {
            RollMany(20, 1);
            Assert.AreEqual(20, g.Score());
        }

        [TestMethod]
        public void OneSpare()
        {
            RollSpare();
            g.Roll(3);
            RollMany(17, 0);
            Assert.AreEqual(16, g.Score());
        }

        [TestMethod]
        public void OneStrike()
        {
            RollStrike();
            g.Roll(3);
            g.Roll(4);
            RollMany(16, 0);
            Assert.AreEqual(24, g.Score());
        }

        [TestMethod]
        public void PerfectGame()
        {
            RollMany(12, 10);
            Assert.AreEqual(300, g.Score());
        }

    }
}
