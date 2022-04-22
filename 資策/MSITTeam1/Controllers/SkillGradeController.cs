using Microsoft.AspNetCore.Mvc;
using MSITTeam1.Models;
using MSITTeam1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.Controllers
{
    public class SkillGradeController : Controller
    {
        private readonly helloContext hello;
        public SkillGradeController(helloContext _hello)
        {
            hello = _hello;
        }
        public IActionResult Index()
        {
            IEnumerable<CTestPaperViewModel> list = null;
                    list = from d in hello.TQuestionDetails
                           join l in hello.TQuestionLists on new { d.FSubjectId, d.FQuestionId } equals new { l.FSubjectId, l.FQuestionId }
                           join p in hello.TTestPapers on new { d.FSubjectId, d.FQuestionId } equals new { p.FSubjectId, p.FQuestionId }
                           where p.FTestPaperId == 25
                           select new CTestPaperViewModel
                           {
                               fQuestionID = p.FSn,
                               fQuestion = l.FQuestion,
                               fChoice = d.FChoice,
                               fCorrectAnswer = d.FCorrectAnswer
                           };
                    return View(list);
        }
        public IActionResult Topic(topic topic)
        {
            if (topic.Grade < 70)
            {
                var TOPIC = (from p in hello.TQuestionLists
                            where p.FLevel == 1
                            orderby Guid.NewGuid()
                            select p).Take(1);
                return Json(TOPIC);
            }
            else if (topic.Grade >= 70 && topic.Grade < 90)
            {
                var TOPIC = (from p in hello.TQuestionLists
                            where p.FLevel == 2
                            orderby Guid.NewGuid()
                            select p).Take(1);
                return Json(TOPIC);
            }
            else
            {
                var TOPIC = (from p in hello.TQuestionLists
                            where p.FLevel == 3
                            orderby Guid.NewGuid()
                            select p).Take(1);
                return Json(TOPIC);
            }
        }
    }
}
