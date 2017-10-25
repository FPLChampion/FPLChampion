using System.Collections.Generic;
using MongoDB.Bson;
using Mvc.Models;
using System;

namespace Mvc.Dal.Interfaces
{
    public interface IPlayerRepository
    {
        List<Player> GetPlayers();
        Player GetPlayer(int id);
    }
}