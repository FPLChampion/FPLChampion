using System.Collections.Generic;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Mvc.Models;

namespace Mvc.Dal
{
    public class PlayerContext
    {
        private readonly IMongoDatabase _database = null;
        
        public PlayerContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public List<Player> Players
        {
            get
            {
                return _database.GetCollection<Player>("Players").Find(_=>true).ToList();
            }
        }

        public Player Player(int id) {
                return _database.GetCollection<Player>("Players").Find(x => x.playerid.Equals(id)).FirstOrDefault();
        }
    }
}