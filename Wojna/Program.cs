namespace Wojna
{
    internal class Program
    {
        private static void Main()
        {
            var talia = new Talia(new[]
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
            
            var pack = new Pack(talia.GetAllCards());

            var wojna = new GraWojna(new Zawodnik("Szymon", pack.DistributeShuffledCards(16)), new Zawodnik("Michal", pack.DistributeShuffledCards(16)), new Zawodnik("Funia", pack.DistributeShuffledCards(16)));
            wojna.Graj();
        }
    }
}