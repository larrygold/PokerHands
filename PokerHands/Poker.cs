using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PokerHands
{
    public class Poker
    {
        private readonly char[] _cardValuesSortedDesc;

        public Poker()
        {
            _cardValuesSortedDesc = new char[] { 'A', 'K', 'Q', 'J', 'T', '9', '8', '7', '6', '5', '4', '3', '2' };
        }

        public Result Compare(string bobsHand, string johnsHand)
        {
            var bobsCards = bobsHand.Split(" ");
            var johnsCards = johnsHand.Split(" ");

            
            /*
            Dommage ici car on fait 2 fois la boucle. On peut les fusionner!            
            */
            foreach (var value in _cardValuesSortedDesc)
            {
                if (ThereIsPairWinnerWithValue(value, bobsCards, johnsCards)) 
                    return GetPairResult(bobsCards, johnsCards, value);
            }

            foreach (var value in _cardValuesSortedDesc)
            {
                if (ThereIsHighCardWinnerWithValue(value, bobsCards, johnsCards))
                    return GetHighCardResult(bobsCards, johnsCards, value);
            }

            return GetTieResult();

        }
        
        private static bool ThereIsPairWinnerWithValue(char value, string[] bobsCards, string[] johnsCards)
        {
            return GetPairResult(bobsCards, johnsCards, value) != null;
        }

        private bool ThereIsHighCardWinnerWithValue(char value, string[] bobsCards, string[] johnsCards)
        {
            return GetHighCardResult(bobsCards, johnsCards, value) != null;
        }

        private static Result GetPairResult(string[] bobsCards, string[] johnsCards, char value)
        {
            return new Pair().WhoWins(bobsCards, johnsCards, value);
        }

        private Result GetHighCardResult(string[] bobsCards, string[] johnsCards, char value)
        {
            return new HighCard().WhoWins(bobsCards, johnsCards, value);
        }

        private static Result GetTieResult()
        {
            return new Result { Winner = "Tie", WinningCard = null, WinningCombination = null };
        }
    }

    public class Result
    {
        public string Winner { get; set; }
        public string WinningCard { get; set; }
        public string WinningCombination { get; set; }
    }

    //C'est un bon reflexe d'utiliser des classes abstraites, mais ma reco aurait été d'associer une classe combination à un joueur (un joueur, c'est un nom et une combination au final)
    //Pour classer les combination, on aurait pu imaginer une méthode qui renvoit un score par ex (genre 0 pour highcard, 1 pour pair, 2 pour double pair...), avec une méthode à côté en cas d'égalité
    //Toujours se ramener au fonctionnel au final, c'est comme ça qu'on peut commencer à tracer une architecture :)
    public abstract class Combination
    {
        public abstract Result WhoWins(string[] player1Cards, string[] player2Cards, char cardValue);
        protected Result WhoWinsHelper(char value, bool bobWins, bool johnWins, string combination)
        {
            if (bobWins && johnWins)
                return null;

            if (bobWins)
                return new Result() { Winner = "Bob", WinningCard = value.ToString(), WinningCombination = combination };

            if (johnWins)
                return new Result() { Winner = "John", WinningCard = value.ToString(), WinningCombination = combination };

            return null;

        }
    }

    public class HighCard : Combination
    {
        public override Result WhoWins(string[] player1Cards, string[] player2Cards, char cardValue)
        {
            var bobHasThisCard = player1Cards.Any(x => x.Contains(cardValue));
            var johnHasThisCard = player2Cards.Any(x => x.Contains(cardValue));
            var combination = "High Card";

            return WhoWinsHelper(cardValue, bobHasThisCard, johnHasThisCard, combination);
        }
    }
    public class Pair : Combination
    {
        public override Result WhoWins(string[] player1Cards, string[] player2Cards, char cardValue)
        {
            var bobHasPair = player1Cards.Count(x => x.Contains(cardValue)) == 2;
            var johnHasPair = player2Cards.Count(x => x.Contains(cardValue)) == 2;
            var combination = "Pair";

            return WhoWinsHelper(cardValue, bobHasPair, johnHasPair, combination);
        }
    }
}
