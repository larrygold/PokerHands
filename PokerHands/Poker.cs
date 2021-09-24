using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PokerHands
{
    public static class Poker
    {
        public static string Compare(string bobsHand, string johnsHand)
        {
            var bobsCards = bobsHand.Split(" ");
            var johnsCards = johnsHand.Split(" ");

            var values = new char[] { 'A', 'K', 'Q', 'J', 'T', '9', '8', '7', '6', '5', '4', '3', '2' };

            foreach (var value in values)
            {
                var whoWins = WhoWins(bobsCards, johnsCards, value);

                if (whoWins != null)
                    return whoWins;
            }

            return "Tie";

        }

        private static string WhoWins(string[] bobsCards, string[] johnsCards, char value)
        {
            var bobWins = bobsCards.Any(x => x.Contains(value));
            var johnWins = johnsCards.Any(x => x.Contains(value));
            
            if (bobWins && johnWins)
                return null;

            if (bobWins)
                return "Bob";
            
            if (johnWins)
                return "John";

            return null;

        }
    }
}
