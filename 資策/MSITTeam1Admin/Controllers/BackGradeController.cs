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
        public IActionResult Index()
        {
            backGrade aa = new backGrade();

            aa.TClassGrade = (from t in hello.TClassGrades
                        select t);
            return View(aa);
        }

        public IActionResult skillIndex()
        {
            backGrade aa = new backGrade();

            aa.TSkillGrade = (from t in hello.TSkillGrades
                              select t);
            return View(aa);
        }
    }
}
