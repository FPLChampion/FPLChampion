using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Mvc.Dal.Interfaces;
using Mvc.Models;

namespace Mvc.Controllers 
{

    [Route("api/[controller]")]
    public class TeamController : Controller
    {
        private readonly ITeamRepository _repo;

        public TeamController(ITeamRepository teamRepository)
        {
            _repo = teamRepository;
        }

        [HttpGet]
        public List<Team> Get()  {
            var teams = _repo.GetTeams();
            
            return  teams;
        } 

        [HttpGet]
        [Route("{id}")] 
        public Team GetTeam(int id) {
            var team = _repo.GetTeam(id);

            return team;
        }
    }
}