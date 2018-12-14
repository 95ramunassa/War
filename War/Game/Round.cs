using System;
using System.Collections.Generic;
using System.Linq;
using War.Cards;

namespace War.Game
{
    public class Round
    {
        private readonly List<Player> _players;
        
        public Round(List<Player> players)
        {
            _players = players;
        }

        public void Play()
        {
            List<Move> moves = new List<Move>(_players.Count);
            List<Player> activePlayers = GetActivePlayers();
            moves.AddRange(getMoves(activePlayers));

            //wars
            bool wars;
            do
            {
                List<Move> nonHiddenMoves = moves.FindAll(move => !move.Hidden);
                Console.WriteLine("Rzucone karty:");
                
                Dictionary<Move, List<Move>> aggregatedMoves = new Dictionary<Move, List<Move>>(moves.Count);
                foreach (var move in nonHiddenMoves)
                {
                    Console.WriteLine($"{move.Player}: {move.Card}");
                    if (aggregatedMoves.ContainsKey(move))
                    {
                        aggregatedMoves[move].Add(move);
                    }
                    else
                    {
                        aggregatedMoves.Add(move, new List<Move>{move});
                    }
                }

                wars = false;
                foreach (var sameCardMove in aggregatedMoves)
                {
                    if (sameCardMove.Value.Count > 1)
                    {
                        Console.WriteLine("Wojna!");
                        foreach (var warMove in sameCardMove.Value)
                        {
                            Console.WriteLine($"[WOJNA] Ruch {warMove.Player.Name}...");
                            if (warMove.Player.HasACard())
                            {
                                warMove.Hidden = true;
                                Card hiddenCard = warMove.Player.ThrowCard();
                                if (warMove.Player.HasACard())
                                {
                                    moves.Add(new Move(warMove.Player, hiddenCard, true));
                                    ThrowInfo(warMove.Player, hiddenCard, true);

                                    Card warCard = warMove.Player.ThrowCard();
                                    ThrowInfo(warMove.Player, warCard, false);
                                    moves.Add(new Move(warMove.Player, warCard, false));
                                }
                                else
                                {
                                    moves.Add(new Move(warMove.Player, hiddenCard, false));
                                    ThrowInfo(warMove.Player, hiddenCard, false);
                                }
                            }
                            else
                            {
                                Console.WriteLine($"[WOJNA] {warMove.Player} nie ma już kart!");
                            }
                        }
                        wars = true;
                    }
                }
            } while (wars);
            
            //who is a winner?
            moves.Sort((m1, m2) => m2.CompareTo(m1));
            Player winner = moves.First(t => !t.Hidden).Player;
            Console.WriteLine($"Zwycięzca rundy: {winner.Name}. Zebrano {moves.Count} karty:");
            foreach (var move in moves)
            {
                Console.WriteLine($"{move.Card} ({move.Player})");
            }
            winner.TakeCards(moves.ConvertAll(move=>move.Card));
        }

        private List<Player> GetActivePlayers()
        {
            List<Player> players = new List<Player>(_players.Count);
            foreach (var player in _players)
            {
                if(player.HasACard())
                    players.Add(player);
            }
            return players;
        }

        private List<Move> getMoves(List<Player> players, bool hidden = false)
        {
            List<Move> moves = new List<Move>(players.Count);
            foreach (var player in players)
            {
                Card card = player.ThrowCard();
                ThrowInfo(player, card, hidden);
                moves.Add(new Move(player, card, hidden));
            }

            return moves;
        }

        private Card ThrowInfo(Player player, Card card, bool hidden)
        {
            Console.WriteLine(hidden
                ? $"{player.Name} (zostało kart: {player.NumberOfCards}) rzucił kartę koszulką do góry. (({card.Name}))"
                : $"{player.Name} (zostało kart: {player.NumberOfCards}) rzucił {card.Name}.");
            return card;
        }
    }
}