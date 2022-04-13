using Microsoft.AspNetCore.Mvc;
using MSITTeam1.Models;
using MSITTeam1.ViewModels;
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
        public IActionResult Index(GradeIdentify Grade)
        {
            IEnumerable<CTestPaperViewModel> list = null;
            if (hello.StudentBasics.FirstOrDefault(c => c.Email == Grade.txtaccount) != null && hello.TClassOrderDetails.FirstOrDefault(q => q.MemberId == (hello.StudentBasics.FirstOrDefault(c => c.Email == Grade.txtaccount).MemberId)).ClassExponent == Grade.txtidentify)
            {
                int Testpaper = int.Parse(hello.TClassInfos.FirstOrDefault(c => c.FClassExponent == Grade.txtidentify).FClassTestpaper);
                list = from d in hello.TQuestionDetails
                       join l in hello.TQuestionLists on new { d.FSubjectId, d.FQuestionId } equals new { l.FSubjectId, l.FQuestionId }
                       join p in hello.TTestPapers on new { d.FSubjectId, d.FQuestionId } equals new { p.FSubjectId, p.FQuestionId }
                       where p.FTestPaperId == Testpaper
                       select new CTestPaperViewModel
                       {
                           fQuestionID = p.FSn,
                           fQuestion = l.FQuestion,
                           fChoice = d.FChoice,
                           fCorrectAnswer = d.FCorrectAnswer
                       };
                ViewBag.Account = Grade.txtaccount;
                ViewBag.Identify = Grade.txtidentify;
                ViewBag.Classname = hello.TClassInfos.FirstOrDefault(c => c.FClassExponent == Grade.txtidentify).FClassname;
                return View(list);
            }
            else
                return View(list);

        }
        public IActionResult Grade(TTestPaper z)
        {
            return Content(z.ToString());
        }
    }
}
