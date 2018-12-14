using System;
using System.Collections.Generic;
using System.Linq;

namespace War.Game
{
    public class Game
    {
        private readonly List<Player> _players;
        private int _roundNumber;

        public Game(params Player[] players)
        {
            _roundNumber = 0;
            _players = new List<Player>();
            foreach (var player in players)
                _players.Add(player);
        }

        public void Play()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("------------- Runda " + ++_roundNumber + " -------------");
                var round = new Round(ActivePlayers());
                round.Play();

                Console.ReadKey();
            } while (ActivePlayers().Count > 1);
        }

        private List<Player> ActivePlayers() => _players.Where(player => player.HasACard()).ToList();
    }
}