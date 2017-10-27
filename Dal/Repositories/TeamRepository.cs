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
        private readonly TeamContext _teamContext = null;
        private readonly PlayerContext _playerContext = null;

        public TeamRepository(IOptions<Settings> settings)
        {
            _teamContext = new TeamContext(settings);
            _playerContext = new PlayerContext(settings);
        }

        public Team GetTeam(int id)
        {
            var team = _teamContext.Team(id);
            return team;
        }

        public List<Team> GetTeams()
        {
            var teams = _teamContext.Teams;

            return teams;
        }

        public List<Player> GetTeamPlayers(int id) {
            var team = GetTeam(id);
            var players = _playerContext.Players.FindAll(player => player.team_code.Equals(team.code));

            return players;
        }
    }
}