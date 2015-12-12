using System.Collections.Generic;
using System.IO;

namespace Wojna
{
    internal class Zawodnik
    {
        private readonly Queue<Card> _cards;
        public string Name { get; }

        public Zawodnik(string name, List<Card> cards)
        {
            Name = name;
            _cards = new Queue<Card>(cards);
        }

        public bool IsHaveCard()
        {
            return _cards.Count > 0;
        }

        public Card CheckCard()
        {
            return _cards.Peek();
        }

        public Card ThrowCard()
        {
            return _cards.Dequeue();
        }

        public void TakeCards(Card[] cards)
        {
            foreach (var card in cards)
            {
                _cards.Enqueue(card);
            }
        }

        public int NumberOfCards => _cards.Count;

        public void PrintCard()
        {
            foreach (var card in _cards)
            {
                card.Print();
            }
        }
    }
}
