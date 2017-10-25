using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mvc.Dal.Interfaces;
using Mvc.Models;
using Mvc.Models.ViewModels;

namespace Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPlayerRepository _repo;

        public HomeController(IPlayerRepository playerRepository)
        {
            _repo = playerRepository;
        }
        public IActionResult Index()
        {
            var model = new HomeViewModel();
            model.Players = _repo.GetPlayersWithCostChangeEvent();

            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page    .";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
