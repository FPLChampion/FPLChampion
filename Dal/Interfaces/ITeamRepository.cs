using System.Collections.Generic;
using MongoDB.Bson;
using Mvc.Models;
using System;

namespace Mvc.Dal.Interfaces
{
    public interface ITeamRepository {
        List<Team> GetTeams();
        Team GetTeam(int id);
        List<Player> GetTeamPlayers(int id);
    }
}