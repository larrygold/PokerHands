using System;
using System.Linq;

namespace PokerHands
{
    public static class Poker
    {
        public static string Compare(string bobsHand, string johnsHand)
        {
            var bobsCards = bobsHand.Split(" ");
            var johnsCards = johnsHand.Split(" ");

            if (bobsCards.Any(x => x.Contains('A')))
                return "Bob";
            else if (johnsCards.Any(x => x.Contains('A')))
                return "John";

            if (bobsCards.Any(x => x.Contains('K')))
                return "Bob";
            else if (johnsCards.Any(x => x.Contains('K')))
                return "John";

            return null;

            /*
            if (bobsHand == "2H 3D 5S 9C AS")
                return "Bob";
            return "John";
        */
        }
    }
}
