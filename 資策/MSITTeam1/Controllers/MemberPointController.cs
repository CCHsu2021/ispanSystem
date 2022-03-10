using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.Controllers
{
    public class MemberPointController : Controller
    {
        public IActionResult Student()
        {
            return View();
        }
    }
}
