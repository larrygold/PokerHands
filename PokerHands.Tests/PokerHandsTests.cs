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

        [TestCase("2H 3D 5S 9C KD", "2C 3H 4S 8C AH", "John", TestName = "Ace John")]
        [TestCase("2H 3D 5S 9C AS", "2H 3D 5S 9C KD", "Bob", TestName = "Ace Bob")]
        [TestCase("2H 3D 5S 9C KD", "2H 3D 5S 9C DS", "Bob")]
        public void Wins_High_Card(string bobsHand, string johnsHand, string winnerExpected)
        {
            var winner = Poker.Compare(bobsHand, johnsHand);
            Assert.AreEqual(winnerExpected, winner);
        }
    }
}