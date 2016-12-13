namespace War.Game
{
    /*
    Normalna runda
    Dla każdego gracza:
	    1. Sprawdź czy gracz może rzucić kartę
		    T: Przejdź dalej
		    N: Przegryw
	    2. Rzuć kartę

    Ustalanie konfliktów
    Dla każdego gracza wykonuj dopóki nie przejdzie do ustalania wyniku
	    1. Sortuj graczy sortowaniem kubełkowym pod względem posiadanej karty
	    2. Sprawdź czy jest kubełek, gdzie graczy >= 2
		    T: Rozegraj dla każdego kubełka Wojnę, jeśli graczy >= 2
		    N: Koniec wojen, przejdź do ustalania wyniku

    Rozgrywanie wojny
    Dla każdego gracza:
	    1. Sprawdź czy gracz może rzucić kartę
		    T: Rzucaj
		    N: Przegraj

    Ustalanie wyniku
	    1. Znajdź największą kartę 
	    2. Ustal do kogo należy
	    3. Wyświetl zwycięzce
    */

    public class War
    {
    }
}