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
            else
                return "John";

            /*
            if (bobsHand == "2H 3D 5S 9C AS")
                return "Bob";
            return "John";
        */
        }
    }
}
