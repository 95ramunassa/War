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
        
        public void Rozegraj(bool czyWojennaRunda = false)
        {
            var cards = CheckCards();
            for (int i = 0; i < _zawodnicy.Count; i++)
            {
                Console.WriteLine(_zawodnicy[i].Name + "(" + _zawodnicy[i].NumberOfCards + ") rzucił: " + cards[i].Name);
            }

            Console.WriteLine("\nRozgrywam...\n");
            var warCards = new List<Card>();
            warCards.AddRange(DoTheWar());
            cards = CheckCards();
            var winCard = EmergeWinnerCard(cards);
            Console.WriteLine("Zwyciezka karta: " + winCard.Name);
            var winner = GetZawodnikByCard(winCard);
            Console.WriteLine("Zwyciezca: " + winner.Name);
            winner.TakeCards(ThrowCards());
            winner.TakeCards(warCards.ToArray());
        }

        private List<Card> DoTheWar()
        {
            var warCards = new List<Card>();
            while (CanWeDoTheWar())
            {
                Console.WriteLine("Wojenna runda...\n");
                var warPlayers = GetWarPlayers();
                warCards.AddRange(warPlayers.Select(player => player.ThrowCard()));
                warCards.AddRange(warPlayers.Select(player => player.ThrowCard()));
                DoTheWar();
            }
            return warCards;
        } 

        private Zawodnik[] GetWarPlayers()
        {
            Card checkedCard = null;
            var zawodnicy = new List<Zawodnik>();
            foreach (var card in CheckCards())
            {
                if (checkedCard == null) checkedCard = card;
                else if (card.IsEqual(checkedCard))
                {
                    var previousZawodnik = GetZawodnikByCard(checkedCard);
                    if(!zawodnicy.Contains(previousZawodnik))
                        zawodnicy.Add(previousZawodnik);
                    zawodnicy.Add(GetZawodnikByCard(card));
                    checkedCard = card;
                }
            }
            return zawodnicy.ToArray();
        }

        private Zawodnik GetZawodnikByCard(Card card) => _zawodnicy.First(zawodnik => zawodnik.CheckCard() == card);

        private bool CanWeDoTheWar()
        {
            var cards = CheckCards().ToArray();
            var checkedCard = cards[0];
            for (int i = 1; i < cards.Length; i++)
            {
                if (cards[i].IsEqual(checkedCard))
                    return true;
            }
            return false;
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
