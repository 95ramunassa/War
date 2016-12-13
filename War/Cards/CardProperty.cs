using System;

namespace War.Cards
{
    public class CardProperty
    {
        public string Name { get; }
        public int HierarchyLevel { get; }

        public CardProperty(string name, int hierarchyLevel)
        {
            Name = name;
            HierarchyLevel = hierarchyLevel;
        }

        public bool IsStronger(CardProperty cardType) => HierarchyLevel > cardType.HierarchyLevel;

        public bool IsWeaker(CardProperty cardType) => HierarchyLevel < cardType.HierarchyLevel;

        public bool IsEqual(CardProperty cardType) => HierarchyLevel == cardType.HierarchyLevel;

        public void Print() => Console.WriteLine(Name);
    }
}