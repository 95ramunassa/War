using System.Collections.Generic;

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

        public Card ThrowCard()
        {
            return _cards.Dequeue();
        }

        public void TakeCard(Card card)
        {
            _cards.Enqueue(card);
        }

        public void PrintCard()
        {
            foreach (var card in _cards)
            {
                card.Print();
            }
        }
    }
}
