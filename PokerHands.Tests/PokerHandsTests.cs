using NUnit.Framework;
using PokerHands;

namespace PokerHands.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Bob_Wins_High_Card()
        {
            var bobsHand = "2H 3D 5S 9C KD";
            var johnsHand = "2C 3H 4S 8C AH";
            var winner = Poker.Compare(bobsHand, johnsHand);
            Assert.AreEqual("Bob", winner);
        }
    }
}