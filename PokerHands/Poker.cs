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

            /*
            if (bobsHand == "2H 3D 5S 9C AS")
                return "Bob";
            return "John";
        */
        }

        private static string WhoWins(string[] bobsCards, string[] johnsCards, char value)
        {
            if (bobsCards.Any(x => x.Contains(value)))
            {
                return "Bob";
            }
            else if (johnsCards.Any(x => x.Contains(value)))
            {
                return "John";
            }

            return null;

        }
    }
}
