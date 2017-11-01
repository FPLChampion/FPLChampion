using System.Collections.Generic;
using DotNetify;
using Mvc.Dal.Interfaces;

namespace Mvc.Models.ViewModels.Players
{
    public class Players : BaseVM
    {
        private readonly ITeamRepository _repo;
        // List<Mvc.Models.Player> PlayerList {get;set;}
        public List<Player> PlayerList {get;set;}
        public string TEST => "TEST";

        public Players(ITeamRepository teamRepository)
        {
            _repo = teamRepository;
            PlayerList = _repo.GetTeamPlayers(1);
        }       
    }
}