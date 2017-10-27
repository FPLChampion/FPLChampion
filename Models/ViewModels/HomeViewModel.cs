using System.Collections.Generic;

namespace Mvc.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<Player> Players {get;set;}
        public List<Team> Teams {get;set;}
        public List<Player> Arsenal {get;set;}
    }
}