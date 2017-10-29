using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Mvc.Models;
using Newtonsoft.Json;

namespace Mvc.Http
{
    
    public class WebClient : IWebClient
    {
        private const string fplUrl = "https://fantasy.premierleague.com/drf/bootstrap-static";
        private readonly HttpClient _httpClient;
        public WebClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Player>> GetPlayersFromFpl(){
            var json = await _httpClient.GetStringAsync(fplUrl);
            var dynJson = JsonConvert.DeserializeObject<dynamic>(json);
            var players = new List<Player>();
            if(dynJson.elements != null){
                var elements = dynJson.elements;

                json = JsonConvert.SerializeObject(elements);
                players = JsonConvert.DeserializeObject<List<Player>>(json);
            }
            return players;
        }

        public async Task<List<Team>> GetTeamsFromFpl(){
            var json = await _httpClient.GetStringAsync(fplUrl);
            var dynJson = JsonConvert.DeserializeObject<dynamic>(json);
            var teams = new List<Team>();
            if(dynJson.teams != null){
                var dynteams = dynJson.teams;

                json = JsonConvert.SerializeObject(dynteams);
                teams = JsonConvert.DeserializeObject<List<Team>>(json);
            }

            return teams;
        }
    }
}