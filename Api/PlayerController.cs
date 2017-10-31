using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Mvc.Dal.Interfaces;
using Mvc.Models;

namespace Mvc.Controllers.Api
{

    [Route("api/[controller]")]
    public class PlayerController : Controller
    {
        private readonly IPlayerRepository _repo;

        public PlayerController(IPlayerRepository playerRepository)
        {
            _repo = playerRepository;
        }

        [HttpGet]
        public List<Player> Get()  {
            var players = _repo.GetPlayers();
            
            return  players;//players; //;
        } 

        [HttpGet]
        [Route("{id}")] 
        public Player GetPlayer(int id) {
            var player = _repo.GetPlayer(id);

            return player;
        }
    }
}