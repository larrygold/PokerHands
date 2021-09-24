using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PokerHands
{
    public static class Poker
    {
        public static (string, string) Compare(string bobsHand, string johnsHand)
        {
            var bobsCards = bobsHand.Split(" ");
            var johnsCards = johnsHand.Split(" ");

            var values = new char[] { 'A', 'K', 'Q', 'J', 'T', '9', '8', '7', '6', '5', '4', '3', '2' };

            foreach (var value in values)
            {
                var whoWins = WhoWins(bobsCards, johnsCards, value).winner;
                var winningCard = WhoWins(bobsCards, johnsCards, value).winningCard;

                if (whoWins != null)
                    return (whoWins, winningCard);
            }

            return ("Tie", null);

        }

        private static (string winner, string winningCard) WhoWins(string[] bobsCards, string[] johnsCards, char value)
        {
            var bobWins = bobsCards.Any(x => x.Contains(value));
            var johnWins = johnsCards.Any(x => x.Contains(value));
            
            if (bobWins && johnWins)
                return (null, null);

            if (bobWins)
                return ("Bob", value.ToString());
            
            if (johnWins)
                return ("John", value.ToString());

            return (null, null);

        }
    }
}
