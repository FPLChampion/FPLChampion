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

        public List<Player> GetPlayers()
        {
            var players = _context.Players;

            return players;
        }
    }
}