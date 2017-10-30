using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Mvc.Models;
using Newtonsoft.Json;

namespace Mvc.Dal
{
    public class TeamContext
    {
        private readonly IMongoDatabase _database = null;
        private const string _teamsCollectionName = "Teams";
        public TeamContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        private IMongoCollection<Team> TeamColletction
        {
            get
            {
                return _database.GetCollection<Team>(_teamsCollectionName);   
            }
        }

        public List<Team> Teams
        {
            get 
            {
                return TeamColletction.Find(_=>true).ToList();
            }
        }

        public Team Team(int id) {
            return TeamColletction.Find(x => x.teamid.Equals(id)).FirstOrDefault();
        }

        public bool UpdateOrCreateTeams(List<Team> teams)
        {
            try
            {
                var teamsCollection = TeamColletction;
                if(teamsCollection == null){
                    _database.CreateCollection(_teamsCollectionName);
                    teamsCollection = TeamColletction;
                }

                teamsCollection.InsertMany(teams);
            }
            catch(Exception)
            {
                return false;
            }

            return true;
        }
    }
}