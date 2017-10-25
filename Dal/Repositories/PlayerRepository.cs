using System.Collections.Generic;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using Mvc.Models;
using Mvc.Dal.Interfaces;

namespace Mvc.Dal.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly FplContext _context = null;

        public PlayerRepository(IOptions<Settings> settings)
        {
            _context = new FplContext(settings);
        }

        public Player GetPlayer(int id)
        {
            var player = _context.Player(id);

            return player;
        }

        public List<Player> GetPlayers()
        {
            var players = _context.Players;

            return players;
        }

        public List <Player> GetPlayersWithCostChangeStart() {
            var players = GetPlayers();
            return players.FindAll(player => player.cost_change_start != 0);
       }

        public List <Player> GetPlayersWithCostChangeEvent() {
            var players = GetPlayers();
            return players.FindAll(player => player.cost_change_event != 0);
       }
    }
}