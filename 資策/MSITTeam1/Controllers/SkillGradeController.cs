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
            ViewBag.account = CDictionary.account;
            ViewBag.memtype = CDictionary.memtype;
            var account = hello.StudentBasics.FirstOrDefault(c => c.MemberId == CDictionary.account);
            if(account != null)
            ViewBag.Account = account.FAccount;
            var TOPIC = from d in hello.TQuestionLists
                        select d;
            return View(TOPIC);
        }
        public IActionResult Topic(skillgrade topic)
        {
            if (topic.FSubmitAnswer != null)
            {
                var sub = hello.TSubmittedAnswers.FirstOrDefault(c => c.FMemberAccount == CDictionary.account && c.FSubjectId == topic.FSubjectId && c.FQuestionId == topic.FQuestionId);
                if (sub == null)
                {
                    TSubmittedAnswer a = new TSubmittedAnswer
                    {
                        FMemberAccount = CDictionary.account,
                        FSubjectId = topic.FSubjectId,
                        FQuestionId = topic.FQuestionId,
                        FSubmitAnswer = topic.FSubmitAnswer
                    };
                    hello.TSubmittedAnswers.Add(a);
                    hello.SaveChanges();
                }
            }
            if (topic.Grade < 50)
            {
                var chose = (from d in hello.TQuestionLists
                             where d.FLevel == 1 && d.FSubjectId == topic.FSubjectId && d.FQuestionTypeId == 1 && d.FQuestionTypeId == 1
                             orderby Guid.NewGuid()
                             select new { d.FQuestion }).Take(1).ToArray();
                string a = chose[0].ToString().Substring(14);
                a = a.Substring(0, a.Length - 2);
                var TOPIC = (from d in hello.TQuestionDetails
                             join l in hello.TQuestionLists on new { d.FSubjectId, d.FQuestionId } equals new { l.FSubjectId, l.FQuestionId }
                             where l.FLevel == 1 && l.FQuestion == a
                             select new CTestPaperViewModel
                             {
                                 fSubjectID = d.FSubjectId,
                                 fQuestionID = d.FQuestionId,
                                 fQuestion = l.FQuestion,
                                 fChoice = d.FChoice,
                                 fCorrectAnswer = d.FCorrectAnswer
                             });
                return Json(TOPIC);
            }
            else if (topic.Grade >= 50 && topic.Grade < 60)
            {
                    var chose = (from d in hello.TQuestionLists
                                 where d.FLevel == 2 && d.FSubjectId == topic.FSubjectId && d.FQuestionTypeId == 1 && d.FQuestionTypeId == 1
                                 orderby Guid.NewGuid()
                                 select new { d.FQuestion }).Take(1).ToArray();
                int x = 2;
                while (chose.FirstOrDefault() == null)
                {
                    x--;
                    chose = (from d in hello.TQuestionLists
                                 where d.FLevel == x && d.FSubjectId == topic.FSubjectId && d.FQuestionTypeId == 1
                             orderby Guid.NewGuid()
                                 select new { d.FQuestion }).Take(1).ToArray();
                }
                string a = chose[0].ToString().Substring(14);
                a = a.Substring(0, a.Length - 2);
                var TOPIC = (from d in hello.TQuestionDetails
                             join l in hello.TQuestionLists on new { d.FSubjectId, d.FQuestionId } equals new { l.FSubjectId, l.FQuestionId }
                             where l.FLevel == x && l.FQuestion == a 
                             //orderby Guid.NewGuid()
                             select new CTestPaperViewModel
                             {
                                 fQuestion = l.FQuestion,
                                 fChoice = d.FChoice,
                                 fCorrectAnswer = d.FCorrectAnswer
                             });
                return Json(TOPIC);
            }
            else if (topic.Grade >= 60 && topic.Grade < 70)
            {
                var chose = (from d in hello.TQuestionLists
                             where d.FLevel == 3 && d.FSubjectId == topic.FSubjectId && d.FQuestionTypeId == 1 && d.FQuestionTypeId == 1
                             orderby Guid.NewGuid()
                             select new { d.FQuestion }).Take(1).ToArray();
                int x = 3;
                while (chose.FirstOrDefault() == null)
                {
                    x--;
                    chose = (from d in hello.TQuestionLists
                             where d.FLevel == x && d.FSubjectId == topic.FSubjectId && d.FQuestionTypeId == 1 && d.FQuestionTypeId == 1
                             orderby Guid.NewGuid()
                             select new { d.FQuestion }).Take(1).ToArray();
                }
                string a = chose[0].ToString().Substring(14);
                a = a.Substring(0, a.Length - 2);
                var TOPIC = (from d in hello.TQuestionDetails
                             join l in hello.TQuestionLists on new { d.FSubjectId, d.FQuestionId } equals new { l.FSubjectId, l.FQuestionId }
                             where l.FLevel == x && l.FQuestion == a
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
                             where d.FLevel == 4 && d.FSubjectId == topic.FSubjectId && d.FQuestionTypeId == 1 && d.FQuestionTypeId == 1
                             orderby Guid.NewGuid()
                             select new { d.FQuestion }).Take(1).ToArray();
                int x = 4;
                while (chose.FirstOrDefault() == null)
                {
                    x--;
                    chose = (from d in hello.TQuestionLists
                             where d.FLevel == x && d.FSubjectId == topic.FSubjectId && d.FQuestionTypeId == 1 && d.FQuestionTypeId == 1
                             orderby Guid.NewGuid()
                             select new { d.FQuestion }).Take(1).ToArray();
                }
                string a = chose[0].ToString().Substring(14);
                a = a.Substring(0, a.Length - 2);
                var TOPIC = (from d in hello.TQuestionDetails
                             join l in hello.TQuestionLists on new { d.FSubjectId, d.FQuestionId } equals new { l.FSubjectId, l.FQuestionId }
                             where l.FLevel == x && l.FQuestion == a
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
                             where d.FLevel == 5 && d.FSubjectId == topic.FSubjectId && d.FQuestionTypeId == 1 && d.FQuestionTypeId == 1
                             orderby Guid.NewGuid()
                             select new { d.FQuestion }).Take(1).ToArray();
                int x = 5;
                while (chose.FirstOrDefault() == null)
                {
                    x--;
                    chose = (from d in hello.TQuestionLists
                             where d.FLevel == x && d.FSubjectId == topic.FSubjectId && d.FQuestionTypeId == 1 && d.FQuestionTypeId == 1
                             orderby Guid.NewGuid()
                             select new { d.FQuestion }).Take(1).ToArray();
                }
                string a = chose[0].ToString().Substring(14);
                a = a.Substring(0, a.Length - 2);
                var TOPIC = (from d in hello.TQuestionDetails
                             join l in hello.TQuestionLists on new { d.FSubjectId, d.FQuestionId } equals new { l.FSubjectId, l.FQuestionId }
                             where l.FLevel == x && l.FQuestion == a
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
        public IActionResult InSQL(skillgrade topic)
        {
            if (topic.Grade != 0)
            {
                var account = hello.StudentBasics.FirstOrDefault(c => c.MemberId == CDictionary.account);
                var sub = hello.TSkillGrades.FirstOrDefault(c => c.FAccount == account.FAccount && c.FSkillCategory == topic.FSubjectId);
                if (sub == null)
                {
                    TSkillGrade a = new TSkillGrade
                    {
                        FAccount = account.FAccount,
                        FSkillCategory = topic.FSubjectId,
                        FMemberName = account.Name,
                        FGrade = topic.Grade
                    };
                    hello.TSkillGrades.Add(a);
                    hello.SaveChanges();
                }
                else {
                    sub.FGrade = topic.Grade;
                    hello.SaveChanges();
                }
            }
            return RedirectToAction("Index","ShowSkillGrade");
        }

    }
}
