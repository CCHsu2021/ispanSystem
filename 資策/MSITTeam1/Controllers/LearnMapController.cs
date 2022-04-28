using Microsoft.AspNetCore.Mvc;
using MSITTeam1.Models;
using MSITTeam1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.Controllers
{

    public class LearnMapController : Controller
    {
        private readonly helloContext hello;
        public LearnMapController(helloContext _hello)
        {
            hello = _hello;
        }
        public IActionResult Index()
        {
            LearnMap LearnMap = new LearnMap();
            var list = from c in hello.TStudioInformations orderby  c.FClassName,c.FClassCategory select c;
            var count = list.Count()/2;
            LearnMap.TStudioInformationleft = list.Take(count).ToList();
            LearnMap.TStudioInformationright = list.Skip(count).ToList();
            return View(LearnMap);
        }
    }
}
