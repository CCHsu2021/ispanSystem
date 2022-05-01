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
            ViewBag.MemberId = CDictionary.account;
            var account = hello.StudentBasics.FirstOrDefault(c => c.MemberId == CDictionary.account);
            if (account != null && hello.TClassOrderDetails.FirstOrDefault(q => q.MemberId == CDictionary.account).ClassExponent == Grade.txtidentify)
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
                ViewBag.account = account.FAccount;
                ViewBag.Identify = Grade.txtidentify;
                ViewBag.Classname = hello.TClassInfos.FirstOrDefault(c => c.FClassExponent == Grade.txtidentify).FClassname;
                return View(list.ToList());
            }
            else
                return View(list);

        }
        public IActionResult Grade(TClassGrade grade)
        {
            var account = hello.StudentBasics.FirstOrDefault(c => c.MemberId == CDictionary.account);
            TClassGrade classGrade = hello.TClassGrades.FirstOrDefault(c => c.FAccountId == account.FAccount);
            if (classGrade == null)
            {
                classGrade = new TClassGrade
                {
                    FAccountId = grade.FAccountId,
                    FClassCode = grade.FClassCode,
                    FBeforeClassGrade = grade.FBeforeClassGrade,
                    FBeforeClassTime = DateTime.Now
                };
                hello.TClassGrades.Add(classGrade);
                hello.SaveChanges();
                return Content("before");
            }
            else if (classGrade.FBeforeClassGrade != null && classGrade.FAfterClassGrade == null)
            {
                classGrade.FAfterClassGrade = grade.FBeforeClassGrade;
                classGrade.FAfterClassTime = DateTime.Now;
                hello.SaveChanges();
                return Content("after");
            }
            else
                return Content("null");
        }
    }
}
