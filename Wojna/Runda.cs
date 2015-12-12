using System;
using System.Collections.Generic;
using System.Linq;

namespace Wojna
{
    internal class Runda
    {
        private readonly List<Zawodnik> _zawodnicy;

        public Runda(List<Zawodnik> zawodnicy)
        {
            _zawodnicy = zawodnicy;
        }
        
        public void Rozegraj()
        {
            var cards = CheckCards();
            for (int i = 0; i < _zawodnicy.Count; i++)
            {
                Console.WriteLine(_zawodnicy[i].Name + "(" + _zawodnicy[i].NumberOfCards + ") rzucił: " + cards[i].Name);
            }
            Console.WriteLine("\nRozgrywam...\n");
            var winCard = EmergeWinnerCard(cards);
            Console.WriteLine("Zwyciezka karta: " + winCard.Name);
            var winner = CheckWinner(winCard);
            Console.WriteLine("Zwyciezca: " + winner.Name);
            winner.TakeCards(ThrowCards());
        }

        private Zawodnik CheckWinner(Card winCard)
        {
            return _zawodnicy.First(zawodnik => zawodnik.CheckCard() == winCard);
        }

        private static Card EmergeWinnerCard(IEnumerable<Card> cards)
        {
            Card winCard = null;
            foreach (var card in cards)
            {
                if (winCard == null)
                {
                    winCard = card;
                }
                else if (card.IsStronger(winCard))
                {
                    winCard = card;
                }
            }
            return winCard;
        }

        private Card[] CheckCards() => _zawodnicy.Select(zawodnik => zawodnik.CheckCard()).ToArray();
        private Card[] ThrowCards() => _zawodnicy.Select(zawodnik => zawodnik.ThrowCard()).ToArray();
    }
}
