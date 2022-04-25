using Microsoft.AspNetCore.Mvc;
using MSITTeam1.Models;
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
            var ClassName = from c in hello.TStudioInformations group c by new { c.FClassName, c.FClassCategory, c.FClassSkill } into g select g.Key;
            var list = from c in hello.TStudioInformations select c;   
            return View(list);
        }
    }
}
