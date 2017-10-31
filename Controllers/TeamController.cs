using Microsoft.AspNetCore.Mvc;
using Mvc.Dal.Interfaces;
using Mvc.Models.ViewModels;

namespace Mvc.Controllers 
{
    public class TeamController : Controller
    {
        private readonly ITeamRepository _teamRepo;
        public TeamController(ITeamRepository teamRepo)
        {
            _teamRepo = teamRepo;
        }

        public IActionResult Index()
        {
            var model = new TeamViewModel();
            model.Teams = _teamRepo.GetTeams();
            model.Arsenal = _teamRepo.GetTeamPlayers(1); // Arsenal = 1... yeah right
            
            return View(model);
        }
    }
   
}