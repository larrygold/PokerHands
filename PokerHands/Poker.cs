using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PokerHands
{
    public static class Poker
    {
        public static Result Compare(string bobsHand, string johnsHand)
        {
            var bobsCards = bobsHand.Split(" ");
            var johnsCards = johnsHand.Split(" ");

            var values = new char[] { 'A', 'K', 'Q', 'J', 'T' , '9', '8', '7', '6', '5', '4', '3', '2' };

            foreach (var value in values)
            {
                if (WhoWinsPair(bobsCards, johnsCards, value) != null) 
                    return WhoWinsPair(bobsCards, johnsCards, value);
            }

            foreach (var value in values)
            {
                if (WhoWinsHighCard(bobsCards, johnsCards, value) != null)
                    return WhoWinsHighCard(bobsCards, johnsCards, value);
            }

            return new Result { Winner = "Tie", WinningCard = null, WinningCombination = null };

        }

        private static Result WhoWinsPair(string[] bobsCards, string[] johnsCards, char value)
        {
            var bobHasPair = bobsCards.Count(x => x.Contains(value)) == 2;
            var johnHasPair = johnsCards.Count(x => x.Contains(value)) == 2;

            if (bobHasPair && johnHasPair)
                return null;

            if (bobHasPair)
                return new Result() {Winner = "Bob", WinningCard = value.ToString(), WinningCombination = "Pair"};

            if (johnHasPair)
                return new Result() {Winner = "John", WinningCard = value.ToString(), WinningCombination = "Pair"};

            return null;
        }

        private static Result WhoWinsHighCard(string[] bobsCards, string[] johnsCards, char value)
        {
            var bobWins = bobsCards.Any(x => x.Contains(value));
            var johnWins = johnsCards.Any(x => x.Contains(value));
            
            if (bobWins && johnWins)
                return null;

            if (bobWins)
                return new Result() { Winner = "Bob", WinningCard = value.ToString(), WinningCombination = "High Card"};
            
            if (johnWins)
                return new Result() { Winner = "John", WinningCard = value.ToString(), WinningCombination = "High Card"};

            return null;

        }
    }

    public class Result
    {
        public string Winner { get; set; }
        public string WinningCard { get; set; }
        public string WinningCombination { get; set; }
    }
}
