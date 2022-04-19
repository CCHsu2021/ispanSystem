using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MSITTeam1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.Controllers
{
    public class Method : Controller
    {
        private readonly helloContext hello;
        IWebHostEnvironment _enviroment;

        public Method(helloContext _hello, IWebHostEnvironment p)
        {
            hello = _hello;
            _enviroment = p;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetCityByCityGroup(string selectedCity)
        {
            var districtlist = from c in hello.TCityContrasts where c.FCityName == selectedCity select c;
            return Json(districtlist);
        }
    }
}
