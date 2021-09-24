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
        [TestCase("2H 3D 5S 9C KD", "2H 3D 5S 9C DS", "Bob", TestName = "K Bob")]
        [TestCase("2C 3H 4S 8C KD", "2H 3D 5S 9C KD", "John", TestName = "John 2nd highest")]
        [TestCase("2C 3H 5S 9C KD", "2H 3D 4S 9C KD", "Bob", TestName = "Bob 3rd highest")]
        public void Wins_High_Card(string bobsHand, string johnsHand, string winnerExpected)
        {
            var winner = Poker.Compare(bobsHand, johnsHand);
            Assert.AreEqual(winnerExpected, winner);
        }
    }
}