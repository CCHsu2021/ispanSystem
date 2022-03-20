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
        public IActionResult Index()
        {
            IEnumerable<CTestPaperViewModel> list = from d in hello.TQuestionDetails
                                                    join l in hello.TQuestionLists on new { d.FSubjectId, d.FQuestionId } equals new { l.FSubjectId, l.FQuestionId }
                                                    join p in hello.TTestPapers on new { d.FSubjectId, d.FQuestionId } equals new { p.FSubjectId, p.FQuestionId }

                                                    where p.FTestPaperId == 24
                                                    select new CTestPaperViewModel {
                                                        fQuestionID = p.FSn,
                                                        fQuestion = l.FQuestion,
                                                        fChoice = d.FChoice,
                                                        fCorrectAnswer = d.FCorrectAnswer
                                                    };

            return View(list);
        }
        public IActionResult Grade(TTestPaper z)
        {
            return Content(z.ToString());
        }
    }
}
