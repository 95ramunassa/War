using System;
using System.Collections.Generic;

namespace Wojna
{
    class GraWojna
    {
        private List<Zawodnik> _zawodnicy;

        public GraWojna(params Zawodnik[] zawodnicy)
        {
            _zawodnicy = new List<Zawodnik>();
            foreach (Zawodnik zawodnik in zawodnicy)
            {
                _zawodnicy.Add(zawodnik);
            }
        }

        public void Graj()
        {
            do
            {
                Runda();
            } while (Console.ReadLine() != "x");
        }

        private void Runda()
        {
            var cards = new List<Card>();
            Console.Clear();
            foreach (var zawodnik in _zawodnicy)
            {
                Card card = zawodnik.ThrowCard();
                cards.Add(card);
                Console.WriteLine(zawodnik.Name + "     " + card.Name);
            }
            Walcz(cards);
        }

        private void Walcz(List<Card> cards)
        {
            Card winCard = null;
            foreach (var card in cards)
            {
                if (winCard == null)
                {
                    winCard = card;
                }
                else
                {
                     //TODO: WOJNA!
                    if (winCard.IsWeaker(card))
                    {
                        winCard = card;
                        Console.WriteLine("Wygrywa " + winCard.Name);
                    }
                    else if (winCard.IsEqual(card))
                    {
                        Console.WriteLine("Remis");
                    }
                    else
                    {
                        Console.WriteLine("Wygrywa " + winCard.Name);
                    }
                }
            }
        }
    }
}
