using System.Collections.Generic;
using MongoDB.Bson;
using Mvc.Models;
using Mvc.Dal.Interfaces;
using System;
using Microsoft.Extensions.Options;

namespace Mvc.Dal.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly FplContext _context = null;

        public TeamRepository(IOptions<Settings> settings)
        {
            _context = new FplContext(settings);
        }

        public Team GetTeam(int id)
        {
            var team = _context.Team(id);

            return team;
        }

        public List<Team> GetTeams()
        {
            var teams = _context.Teams;

            return teams;
        }
    }
}