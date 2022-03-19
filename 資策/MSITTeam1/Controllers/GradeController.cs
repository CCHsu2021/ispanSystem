using Microsoft.AspNetCore.Mvc;
using MSITTeam1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.Controllers
{
    public class GradeController : Controller
    {
        private readonly helloContext hello;
        public GradeController(helloContext _hello)
        {
            hello = _hello;
        }
        public IActionResult Index()
        {
            IEnumerable<TClassTestPaper> list = from t in hello.TClassTestPapers
                                         select t;

            return View(list);
        }
        public IActionResult Grade(TTestPaper z)
        {
            return Content(z.ToString());
        }
    }
}
