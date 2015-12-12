using System.Collections.Generic;

namespace Wojna
{
    internal class Runda
    {
        private readonly List<Zawodnik> _zawodnicy;

        public Runda(List<Zawodnik> zawodnicy)
        {
            _zawodnicy = zawodnicy;
        }
    }
}
