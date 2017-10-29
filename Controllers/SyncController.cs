using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using Mvc.Dal;
using Microsoft.Extensions.Options;
using Mvc.Models;
using System.Threading.Tasks;
using Mvc.Http;
using System.Linq;

namespace MvcMovie.Controllers
{
    [Route("api/[controller]")]
    public class SyncController : Controller
    {
        private readonly PlayerContext _pcontext = null;
        private readonly TeamContext _tcontext = null;
        private readonly IWebClient _webClient;
        public SyncController(IOptions<Settings> settings, IWebClient webClient)
        {
            _pcontext = new PlayerContext(settings);
            _tcontext = new TeamContext(settings);
            _webClient = webClient;
        }
        
        [HttpGet]
        public async Task<string> Index()
        {
            var players = await _webClient.GetPlayersFromFpl();
            var teams = await _webClient.GetTeamsFromFpl();

            if(players.Any()){
                _pcontext.UpdateOrCreatePlayers(players);
            }

            if(teams.Any()){
                _tcontext.UpdateOrCreateTeams(teams);
            }

            return "DONE";
        }
    }
}