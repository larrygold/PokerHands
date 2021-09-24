using NUnit.Framework;
using PokerHands;
using FluentAssertions;

namespace PokerHands.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("2H 3D 5S 9C KD", "2C 3H 4S 8C AH", "John", "A" , TestName = "Ace John")]
        [TestCase("2H 3D 5S 9C AS", "2H 3D 5S 9C KD", "Bob", "A", TestName = "Ace Bob")]
        [TestCase("2H 3D 5S 9C KD", "2H 3D 5S 9C DS", "Bob", "K", TestName = "K Bob")]
        [TestCase("2C 3H 4S 8C KD", "2H 3D 5S 9C KD", "John", "9", TestName = "John 2nd highest")]
        [TestCase("2C 3H 5S 9C KD", "2H 3D 4S 9C KD", "Bob", "5", TestName = "Bob 3rd highest")]
        public void High_Card(string bobsHand, string johnsHand, string winnerExpected, string winningCardExpected)
        {
            var actual = Poker.Compare(bobsHand, johnsHand);
            var expected = new Result() { Winner = winnerExpected, WinningCard = winningCardExpected, WinningCombination = "High Card" };
            expected.Should().BeEquivalentTo(actual);
        }

        [TestCase("2C 3H 5S 9C KD", "2C 3H 5S 9C KD", "Tie", TestName = "Tie")]
        public void Tie(string bobsHand, string johnsHand, string winnerExpected)
        {
            var actual = Poker.Compare(bobsHand, johnsHand);
            var expected = new Result() {Winner = winnerExpected, WinningCard = null, WinningCombination = null};
            expected.Should().BeEquivalentTo(actual);

        }

        [TestCase("2C 3D 5H TS TC", "1S 3H 5D TC KC", "Bob", "T", TestName =  "Bob Pair T")]
        [TestCase("2C 3D 5H QS TC", "1S 3H 5D TS TC", "John", "T", TestName = "John Pair T")]
        [TestCase("2C 3D 5D QS TC", "1S 3D 3S QS TC", "John", "3", TestName = "John Pair 3")]
        public void Pairs(string bobsHand, string johnsHand, string winnerExpected, string winningCardExpected)
        {
            var actual = Poker.Compare(bobsHand, johnsHand);
            var expected = new Result() { Winner = winnerExpected, WinningCard = winningCardExpected, WinningCombination = "Pair" };
            expected.Should().BeEquivalentTo(actual);
        }

        [TestCase("2C 3D 3H QS TC", "1S 3D 3S QS QD", "John", "Q", "Pair", TestName = "John's pair is higher than Bob's")]
        [TestCase("1C 2D 3H QS QH", "1S 2D 4S QS QD", "John", "4", "High Card", TestName = "John's highest remaining card is higher than Bob's")]
        public void Two_Pairs(string bobsHand, string johnsHand, string winnerExpected, string winningCardExpected, string winningCombination)
        {
            var actual = Poker.Compare(bobsHand, johnsHand);
            var expected = new Result() { Winner = winnerExpected, WinningCard = winningCardExpected, WinningCombination = winningCombination };
            expected.Should().BeEquivalentTo(actual);
        }

    }
}