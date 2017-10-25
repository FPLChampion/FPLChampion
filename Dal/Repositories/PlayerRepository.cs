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
            
            players.FindAll(player => player.cost_change_start != 0).Sort((a, b) => 
                a.cost_change_start < b.cost_change_start 
                    ? -1
                    : a.cost_change_start > b.cost_change_start ? 1 : 0);

            return players;
       }

        public List <Player> GetPlayersWithCostChangeEvent() {
            var players = GetPlayers();
            players.FindAll(player => player.cost_change_event != 0).Sort((a, b) => 
                a.cost_change_event < b.cost_change_event 
                    ? -1
                    : a.cost_change_event > b.cost_change_event ? 1 : 0);

            return players;
       }
    }
}