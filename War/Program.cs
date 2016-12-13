using War.Cards;
using War.Game;

namespace War
{
    internal class Program
    {
        private static void Main()
        {
            var deck = new Deck(new[]
            {
                new CardColour("♥", 0),
                new CardColour("♠", 0),
                new CardColour("♦", 0),
                new CardColour("♣", 0)
            }, new[]
            {
                new CardType("Dwójka", 2),
                new CardType("Trójka", 3),
                new CardType("Czwórka", 4),
                new CardType("Piątka", 5),
                new CardType("Szóstka", 6),
                new CardType("Siódemka", 7),
                new CardType("Ósemka", 8),
                new CardType("Dziewiątka", 9),
                new CardType("Dziesiątka", 10),
                new CardType("Walet", 11),
                new CardType("Dama", 12),
                new CardType("Król", 13),
                new CardType("As", 14)
            });
            
            var pack = new Pack(deck.GetAllCards());

            var war = new Game.Game(new Player("Szymon", pack.DistributeShuffledCards(16)), new Player("Michal", pack.DistributeShuffledCards(16)), new Player("Funia", pack.DistributeShuffledCards(16)));
            war.Play();
        }
    }
}