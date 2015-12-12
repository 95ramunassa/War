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
            Card winCard = EmergeWinnerCard(CheckCards());
            Zawodnik winner = CheckWinner(winCard);
            winner.TakeCards(ThrowCards());
        }

        private Zawodnik CheckWinner(Card winCard)
        {
            return _zawodnicy.First(zawodnik => zawodnik.CheckCard() == winCard);
        }

        private Card EmergeWinnerCard(Card[] cards)
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
