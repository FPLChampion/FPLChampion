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

        public List<Player> Players
        {
            get
            {
                return _database.GetCollection<Player>(_playersCollectionName).Find(_=>true).ToList();
            }
        }

        public Player Player(int id) {
                return _database.GetCollection<Player>(_playersCollectionName).Find(x => x.playerid.Equals(id)).FirstOrDefault();
        }

        public bool UpdateOrCreatePlayers()
        {
            try
            {
                var playerCollections = _database.GetCollection<Player>(_playersCollectionName);
                if(playerCollections == null){
                    _database.CreateCollection(_playersCollectionName);
                    playerCollections = _database.GetCollection<Player>(_playersCollectionName);
                }

                using (StreamReader r = new StreamReader("data/players.json"))
                {
                    string json = r.ReadToEnd();

                    List<Player> players = JsonConvert.DeserializeObject<List<Player>>(json);
                    playerCollections.InsertMany(players);
                }
            }
            catch(Exception)
            {
                return false;
            }

            return true;
        }
    }
}