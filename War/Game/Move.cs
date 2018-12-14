using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using War.Cards;

namespace War.Game
{
    public class Move : IComparable<Move>
    {
        public readonly Player Player;
        public readonly Card Card;
        public bool Hidden;

        public Move(Player player, Card card, bool hidden)
        {
            Player = player;
            Card = card;
            Hidden = hidden;
        }

        protected bool Equals(Move other)
        {
            return Equals(Card, other.Card);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Move) obj);
        }

        public override int GetHashCode()
        {
            return (Card != null ? Card.GetHashCode() : 0);
        }

        public int CompareTo(Move other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return Card.CompareTo(other.Card);
        }
    }
}
