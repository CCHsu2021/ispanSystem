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
                var chose = (from d in hello.TQuestionLists
                             where d.FLevel == 1
                             orderby Guid.NewGuid()
                             select new { d.FQuestion }).Take(1).ToArray();
                string a = chose[0].ToString().Substring(14);
                a = a.Substring(0, a.Length - 2);
                var TOPIC = (from d in hello.TQuestionDetails
                             join l in hello.TQuestionLists on new { d.FSubjectId, d.FQuestionId } equals new { l.FSubjectId, l.FQuestionId }
                             where l.FLevel == 1 && l.FQuestion == a
                             //orderby Guid.NewGuid()
                             select new CTestPaperViewModel
                             {
                                 fQuestion = l.FQuestion,
                                 fChoice = d.FChoice,
                                 fCorrectAnswer = d.FCorrectAnswer
                             });
                return Json(TOPIC);
            }
            else if (topic.Grade >= 70 && topic.Grade < 90)
            {
                var chose = (from d in hello.TQuestionLists
                             where d.FLevel == 2
                             orderby Guid.NewGuid()
                             select new { d.FQuestion }).Take(1).ToArray();
                string a = chose[0].ToString().Substring(14);
                a = a.Substring(0, a.Length - 2);
                var TOPIC = (from d in hello.TQuestionDetails
                             join l in hello.TQuestionLists on new { d.FSubjectId, d.FQuestionId } equals new { l.FSubjectId, l.FQuestionId }
                             where l.FLevel == 2 && l.FQuestion == a
                             //orderby Guid.NewGuid()
                             select new CTestPaperViewModel
                             {
                                 fQuestion = l.FQuestion,
                                 fChoice = d.FChoice,
                                 fCorrectAnswer = d.FCorrectAnswer
                             });
                return Json(TOPIC);
            }
            else
            {
                var chose = (from d in hello.TQuestionLists
                             where d.FLevel == 3
                             orderby Guid.NewGuid()
                             select new { d.FQuestion }).Take(1).ToArray();
                string a = chose[0].ToString().Substring(14);
                a = a.Substring(0, a.Length - 2);
                var TOPIC = (from d in hello.TQuestionDetails
                             join l in hello.TQuestionLists on new { d.FSubjectId, d.FQuestionId } equals new { l.FSubjectId, l.FQuestionId }
                             where l.FLevel == 3 && l.FQuestion == a
                             //orderby Guid.NewGuid()
                             select new CTestPaperViewModel
                             {
                                 fQuestion = l.FQuestion,
                                 fChoice = d.FChoice,
                                 fCorrectAnswer = d.FCorrectAnswer
                             });
                return Json(TOPIC);
            }
        }
    }
}
