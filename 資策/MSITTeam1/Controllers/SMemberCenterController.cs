using Microsoft.AspNetCore.Mvc;
using MSITTeam1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.Controllers
{
    public class SMemberCenterController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Name = CDictionary.username;
            ViewBag.Type = CDictionary.memtype;
            return View();
        }
        public IActionResult Information()
        {
            return PartialView("Information", null);
        }
    }
}
