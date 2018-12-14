using System;

namespace War.Cards
{
    public class CardProperty : IComparable<CardProperty>
    {
        public CardProperty(string name, int hierarchyLevel)
        {
            Name = name;
            HierarchyLevel = hierarchyLevel;
        }

        public string Name { get; }
        public int HierarchyLevel { get; }

        public bool IsStronger(CardProperty cardType) => HierarchyLevel > cardType.HierarchyLevel;

        public bool IsWeaker(CardProperty cardType) => HierarchyLevel < cardType.HierarchyLevel;

        public bool IsEqual(CardProperty cardType) => HierarchyLevel == cardType.HierarchyLevel;

        public void Print() => Console.WriteLine(Name);

        public int CompareTo(CardProperty other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return HierarchyLevel.CompareTo(other.HierarchyLevel);
        }

        protected bool Equals(CardProperty other)
        {
            return HierarchyLevel == other.HierarchyLevel;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CardProperty) obj);
        }

        public override int GetHashCode()
        {
            return HierarchyLevel;
        }
    }
}