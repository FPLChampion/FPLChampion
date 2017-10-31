using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Mvc.Models;
using Newtonsoft.Json;

namespace Mvc.Dal
{
    public class PlayerContext
    {
        private readonly IMongoDatabase _database = null;
        private const string _playersCollectionName = "Players";
        public PlayerContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }
        private IMongoCollection<Player> PlayerCollection
        {
            get
            {
                return _database.GetCollection<Player>(_playersCollectionName);
            }
        }

        public List<Player> Players
        {
            get
            {
                return PlayerCollection.Find(_=>true).ToList();
            }
        }

        public Player Player(int id) {
                return PlayerCollection.Find(x => x.id.Equals(id)).FirstOrDefault();
        }

        public bool UpdateOrCreatePlayers(List<Player> players)
        {
            try
            {
                _database.DropCollection(_playersCollectionName);
                _database.CreateCollection(_playersCollectionName);

                PlayerCollection.InsertMany(players);
            }
            catch(Exception)
            {
                return false;
            }

            return true;
        }
    }
}