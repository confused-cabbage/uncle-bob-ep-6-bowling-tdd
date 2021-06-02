using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingTDDNS;

namespace BowlingUnitTest
{
    [TestClass]
    public class BowlingGameTests
    {
        private Game g;
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
        [Ignore("Ignoring the spare")]
        public void OneSpare()
        {
            g.Roll(5);
            g.Roll(5); // spare
            g.Roll(3);
            RollMany(17, 0);
            Assert.AreEqual(16, g.Score());
        }

        private void RollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
                g.Roll(pins);
        }
    }
}
