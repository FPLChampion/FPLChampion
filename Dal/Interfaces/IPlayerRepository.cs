using System.Collections.Generic;
using MongoDB.Bson;
using Mvc.Models;

namespace Mvc.Dal.Interfaces
{
    public interface IPlayerRepository
    {
        List<Player> GetPlayers();
    }
}