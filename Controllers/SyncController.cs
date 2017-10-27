using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using Mvc.Dal;
using Microsoft.Extensions.Options;
using Mvc.Models;

namespace MvcMovie.Controllers
{
    [Route("api/[controller]")]
    public class SyncController : Controller
    {
        private readonly PlayerContext _pcontext = null;
        private readonly TeamContext _tcontext = null;

        public SyncController(IOptions<Settings> settings)
        {
            _pcontext = new PlayerContext(settings);
            _tcontext = new TeamContext(settings);
        }
        
        [HttpGet]
        public string Index()
        {
           _pcontext.UpdateOrCreatePlayers();
           _tcontext.UpdateOrCreateTeams();

            return "Done";
        }
    }
}