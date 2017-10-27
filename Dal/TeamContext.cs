using System.Collections.Generic;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Mvc.Models;

namespace Mvc.Dal
{
    public class TeamContext
    {
        private readonly IMongoDatabase _database = null;

        public TeamContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public List<Team> Teams 
        {
            get 
            {
                return _database.GetCollection<Team>("Teams").Find(_=>true).ToList();
            }
        }

        public Team Team(int id) {
            return _database.GetCollection<Team>("Teams").Find(x => x.teamid.Equals(id)).FirstOrDefault();
        }
    }
}