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

            var values = new char[] { '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A' };

            foreach (var value in values.Reverse())
            {
                var whoWins = WhoWins(bobsCards, johnsCards, value);

                if (whoWins != null)
                {
                    return whoWins;
                }
            }

            return null;

        }

        private static string WhoWins(string[] bobsCards, string[] johnsCards, char value)
        {
            var bobWins = bobsCards.Any(x => x.Contains(value));
            var johnWins = johnsCards.Any(x => x.Contains(value));
            
            if (bobWins && johnWins)
                return null;

            if (bobWins)
            {
                return "Bob";
            }
            if (johnWins)
            {
                return "John";
            }

            return null;

        }
    }
}
