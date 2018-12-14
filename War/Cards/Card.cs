using System;

namespace War.Cards
{
    public class Card : IComparable<Card>
    {
        private readonly CardColour _color;
        private readonly CardType _type;

        //--- Konstruktor i metody ---
        public Card(CardType type, CardColour color)
        {
            _type = type;
            _color = color;
        }

        public string Name => _type.Name + " " + _color.Name;

        public bool IsStronger(Card card)
        {
            if (_type.IsStronger(card._type))
                return true;
            return _type.IsEqual(card._type) && _color.IsStronger(card._color);
        }

        public bool IsWeaker(Card card)
        {
            if (_type.IsWeaker(card._type))
                return true;
            return _type.IsEqual(card._type) && _color.IsWeaker(card._color);
        }

        public bool IsEqual(Card card) => _type.IsEqual(card._type) && _color.IsEqual(card._color);

        public void Print() => Console.WriteLine(Name);

        protected bool Equals(Card other)
        {
            return Equals(_type, other._type);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Card) obj);
        }

        public override int GetHashCode()
        {
            return (_type != null ? _type.GetHashCode() : 0);
        }

        public int CompareTo(Card other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return _type.CompareTo(other._type);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}