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
        private IMongoCollection<Player> PlayersCollection
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
                return PlayersCollection.Find(_=>true).ToList();
            }
        }

        public Player Player(int id) {
                return PlayersCollection.Find(x => x.playerid.Equals(id)).FirstOrDefault();
        }

        public bool UpdateOrCreatePlayers()
        {
            try
            {
                var playerCollections = PlayersCollection;
                if(playerCollections == null){
                    _database.CreateCollection(_playersCollectionName);
                    playerCollections = PlayersCollection;
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