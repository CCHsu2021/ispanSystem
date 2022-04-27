using Microsoft.AspNetCore.Mvc;
using MSITTeam1Admin.Models;
using MSITTeam1Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1Admin.Controllers
{
    public class BackGradeController : Controller
    {
        private readonly helloContext hello;
        public BackGradeController(helloContext _hello)
        {
            hello = _hello;
        }
        public IActionResult Index(showpage showpage)
        {
            
            backGrade aa = new backGrade();
            ViewBag.classpage = showpage.classpage;
            ViewBag.skillpage = showpage.skillpage;

            aa.TClassGrade = (from t in hello.TClassGrades
                        select t).Skip(showpage.classpage).Take(3);
            aa.TSkillGrade = (from t in hello.TSkillGrades
                             select t).Skip(showpage.skillpage).Take(3);
            return View(aa);
        }
    }
}
