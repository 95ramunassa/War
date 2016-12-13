using System;
using System.Collections.Generic;
using System.Linq;
using War.Cards;

namespace War.Game
{
    public class Round
    {
        private readonly List<Player> _players;

        public Round(List<Player> players)
        {
            _players = players;
        }

        public void Play(bool isItAWarRound = false)
        {
            var cards = CheckCards();
            for (var i = 0; i < _players.Count; i++)
                Console.WriteLine(_players[i].Name + "(" + _players[i].NumberOfCards + ") rzucił: " + cards[i].Name);

            Console.WriteLine("\nRozgrywam...\n");
            var warCards = new List<Card>();
            warCards.AddRange(DoTheWar());
            cards = CheckCards();
            var winCard = EmergeWinnerCard(cards);
            Console.WriteLine("Zwyciezka karta: " + winCard.Name);
            var winner = GetPlayerByCard(winCard);
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

        private Player[] GetWarPlayers()
        {
            Card checkedCard = null;
            var players = new List<Player>();
            foreach (var card in CheckCards())
                if (checkedCard == null) checkedCard = card;
                else if (card.IsEqual(checkedCard))
                {
                    var previousZawodnik = GetPlayerByCard(checkedCard);
                    if (!players.Contains(previousZawodnik))
                        players.Add(previousZawodnik);
                    players.Add(GetPlayerByCard(card));
                    checkedCard = card;
                }
            return players.ToArray();
        }

        private Player GetPlayerByCard(Card card) => _players.First(zawodnik => zawodnik.CheckCard() == card);

        private bool CanWeDoTheWar()
        {
            var cards = CheckCards().ToArray();
            var checkedCard = cards[0];
            for (var i = 1; i < cards.Length; i++)
                if (cards[i].IsEqual(checkedCard))
                    return true;
            return false;
        }

        private static Card EmergeWinnerCard(IEnumerable<Card> cards)
        {
            Card winCard = null;
            foreach (var card in cards)
                if (winCard == null)
                    winCard = card;
                else if (card.IsStronger(winCard))
                    winCard = card;
            return winCard;
        }

        private Card[] CheckCards() => _players.Select(player => player.CheckCard()).ToArray();
        private Card[] ThrowCards() => _players.Select(player => player.ThrowCard()).ToArray();
    }
}