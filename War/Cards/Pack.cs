using System;
using System.Collections.Generic;

namespace War.Cards
{
    public class Pack
    {
        private readonly List<Card> _cards;

        public Pack(List<Card> cards)
        {
            _cards = cards;
        }

        public int CardsAmmount => _cards.Count;

        public List<Card> DistributeShuffledCards(int ammount)
        {
            //TODO: Throw an exepction when ammount > _cards.length
            var random = new Random();
            var cards = new List<Card>();
            for (var i = 0; i < ammount; i++)
            {
                var index = random.Next(_cards.Count);
                cards.Add(_cards[index]);
                _cards.RemoveAt(index);
            }
            return cards;
        }

        public void Print()
        {
            foreach (var card in _cards)
                card.Print();
        }
    }
}