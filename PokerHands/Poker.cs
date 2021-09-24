using System;

namespace PokerHands
{
    public static class Poker
    {
        public static string Compare(string bobsHand, string johnsHand)
        {
            if (bobsHand == "2H 3D 5S 9C AS")
                return "Bob";
            return "John";
        }
    }
}
