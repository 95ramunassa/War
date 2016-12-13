using System;
using System.Collections.Generic;

namespace War.Deck
{
    public class Talia
    {
        private readonly CardColour[] _cardColours;
        private readonly CardType[] _cardTypes;

        public Talia(CardColour[] cardColours, CardType[] cardTypes)
        {
            _cardColours = cardColours;
            _cardTypes = cardTypes;
        }

        public Card GetCard(int type, int color) => new Card(_cardTypes[type], _cardColours[color]);

        public List<Card> GetCards(int type, int color, int ammount)
        {
            var cards = new List<Card>(ammount);
            for (int i = 0; i < ammount; i++)
            {
                cards.Add(GetCard(type, color)); 
            }
            return cards;
        }

        public List<Card> GetAllCards(int ammount = 1)
        {
            var cards = new List<Card>(ammount*_cardTypes.Length*_cardColours.Length);
            for (int type = 0; type < _cardTypes.Length; type++)
            {
                for (int color = 0; color < _cardColours.Length; color++)
                {
                    cards.AddRange(GetCards(type, color, ammount));
                }
            }
            return cards;
        }

        public void PrintCardTypes()
        {
            Console.WriteLine("Typy kart w talii:");
            foreach (var type in _cardTypes)
            {
                type.Print();
            }
        }

        public void PrintCardColors()
        {
            Console.WriteLine("Kolory kart w talii:");
            foreach (var color in _cardColours)
            {
                color.Print();
            }
        }
    }
}