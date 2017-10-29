using System.Collections.Generic;
using System.Threading.Tasks;
using Mvc.Models;

namespace Mvc.Http
{
    public interface IWebClient
    {
        Task<List<Player>> GetPlayersFromFpl();
        Task<List<Team>> GetTeamsFromFpl();
    }
}