using System;
using System.Collections.Generic;
using System.Linq;

namespace War.Game
{
    public class GraWojna
    {
        private readonly List<Zawodnik> _zawodnicy;
        private int _nrRundy;

        public GraWojna(params Zawodnik[] zawodnicy)
        {
            _nrRundy = 0;
            _zawodnicy = new List<Zawodnik>();
            foreach (var zawodnik in zawodnicy)
            {
                _zawodnicy.Add(zawodnik);
            }
        }

        public void Graj()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("------------- Runda " + ++_nrRundy + " -------------");
                var runda = new Runda(AktywniZawodnicy());
                runda.Rozegraj();

                Console.ReadKey();
            } while (AktywniZawodnicy().Count > 1);
        }

        private List<Zawodnik> AktywniZawodnicy() =>  _zawodnicy.Where(zawodnik => zawodnik.IsHaveCard()).ToList();
    }
}
