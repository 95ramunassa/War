using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Wojna
{
    internal class GraWojna
    {
        private readonly List<Zawodnik> _zawodnicy;
        private int _nrRundy;

        public GraWojna(params Zawodnik[] zawodnicy)
        {
            _nrRundy = 0;
            _zawodnicy = new List<Zawodnik>();
            foreach (var zawodnik in zawodnicy)
            {
                _zawodnicy.Add(zawodnik);
            }
        }

        public void Graj()
        {
            do
            {
                Console.WriteLine("Runda " + _nrRundy);
                var runda = new Runda(AktywniZawodnicy());
                runda.Rozegraj();

                Thread.Sleep(100);
            } while (true);
        }

        private List<Zawodnik> AktywniZawodnicy() =>  _zawodnicy.Where(zawodnik => zawodnik.IsHaveCard()).ToList();


        /*private bool Runda()
        {
            var cards = new List<Card>();
            Console.WriteLine("Runda " + (++_nrRundy) + "!");

            foreach (var zawodnik in _zawodnicy)
            {
                if (zawodnik.IsHaveCard())
                {
                    var card = zawodnik.ThrowCard();
                    cards.Add(card);
                    Console.WriteLine(zawodnik.Name + " rzucił: " + card.Name);
                }
                else
                {
                    Console.WriteLine(zawodnik.Name + " przegrał!");
                    _zawodnicy.Remove(zawodnik);
                    Runda();
                    break;
                }
            }

            if (cards.Count <= 1)
            {
                TypujZwyciezce();
                return false;
            }
            Walcz(cards);
            return true;
        }

        private void TypujZwyciezce()
        {
            foreach (var zawodnik in _zawodnicy.Where(zawodnik => zawodnik.IsHaveCard()))
            {
                Console.WriteLine(zawodnik.Name + " wygrał");
                return;
            }
            Console.WriteLine("Remis!");
        }

        private Card Walcz(List<Card> cards)
        {
            Console.WriteLine();

            Card winCard = null;
            foreach (var card in cards)
            {
                if (winCard == null)
                {
                    winCard = card;
                }
                else
                {
                    if (winCard.IsWeaker(card))
                    {
                        winCard = card;
                    }
                }
            }

            return winCard;
        }*/
    }
}
