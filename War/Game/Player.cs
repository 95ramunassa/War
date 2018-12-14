using System.Collections.Generic;
using War.Cards;

namespace War.Game
{
    public class Player
    {
        private readonly Queue<Card> _cards;

        public Player(string name, List<Card> cards)
        {
            Name = name;
            _cards = new Queue<Card>(cards);
        }

        public string Name { get; }

        public int NumberOfCards => _cards.Count;

        public bool HasACard()
        {
            return _cards.Count > 0;
        }

        public Card CheckCard()
        {
            return HasACard() ? _cards.Peek() : null;
        }

        public Card ThrowCard()
        {
            return HasACard() ? _cards.Dequeue() : null;
        }

        public void TakeCards(List<Card> cards)
        {
            foreach (var card in cards)
                _cards.Enqueue(card);
        }

        public void PrintCard()
        {
            foreach (var card in _cards)
                card.Print();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}