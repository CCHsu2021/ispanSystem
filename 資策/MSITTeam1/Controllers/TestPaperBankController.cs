using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MSITTeam1.Models;
using MSITTeam1.ViewModels;

namespace MSITTeam1.Controllers
{
    public class TestPaperBankController : Controller
    {
        private readonly helloContext _context;

        public TestPaperBankController(helloContext context)
        {
            _context = context;
        }

        public IActionResult Home()
		{
            ViewBag.Name = CDictionary.username;
            ViewBag.Type = CDictionary.memtype;
            ViewBag.account = CDictionary.account;

            return View();
		}

        // GET: TTestPaperBanks
        public IActionResult Index()
        {
            ViewBag.Name = CDictionary.username;
            ViewBag.Type = CDictionary.memtype;
            ViewBag.account = CDictionary.account;

            List<CTestPaperBankViewModel> paperList = new List<CTestPaperBankViewModel>();
            var paperQuery = from t in _context.TTestPaperBanks
                             select new CTestPaperBankViewModel
                             {
                                 FTestPaperName = t.FTestPaperName,
                                 FTestPaperId = t.FTestPaperId,
                                 FDesignerAccount = t.FDesignerAccount,
                                 FBSubjectId = t.FSubjectId,
                                 FNote = t.FNote
                             };
            foreach(var t in paperQuery)
			{
                paperList.Add(t);
			}

            return View(paperList);
        }

        [HttpPost]
        public IActionResult CreatNewPaper([Bind("FTestPaperId,FDesignerAccount,FTestPaperName,FSubjectId,FNote")][FromBody] CTestPaperBankViewModel newpaper)
		{
            // 試卷總覽新增
            // TODO1:加入身份判斷
            ViewBag.Name = CDictionary.username;
            ViewBag.Type = CDictionary.memtype;
            ViewBag.account = CDictionary.account;
            if(CDictionary.account != null)
			{
                newpaper.FDesignerAccount = CDictionary.account;
			}
			else
			{
                newpaper.FDesignerAccount = "admin";
            }
            newpaper.FBTestPaperId = 0;
            _context.TTestPaperBanks.Add(newpaper.paperBank);
            _context.SaveChanges();

            // 取得新生成的paperId 以將使用者選取的題目存入tTestPaper
            var getPaperId = (from q in _context.TTestPaperBanks
                         orderby q.FTestPaperId descending
                         select q.FTestPaperId).First();               

            foreach(var question in newpaper.SelectQuestionList)
			{
                newpaper.FTestPaperId = getPaperId;
                newpaper.FSN = 0;
                newpaper.FSubjectId = question.FSubjectId;
                newpaper.FQuestionId = Convert.ToInt32(question.FQuestionId);
                _context.TTestPapers.Add(newpaper.testPaper);
                _context.SaveChanges();
            }
            return Content("新增成功");
		}

        public IActionResult DetailOfPaper(int? paperID)
		{
            ViewBag.Name = CDictionary.username;
            ViewBag.Type = CDictionary.memtype;
            ViewBag.account = CDictionary.account;

            // TODO:4.迴圈要拆開 There is already an open DataReader associated with this Connection which must be closed first.
            if (paperID == null || paperID == 0)
			{
                return Content($"查無ID為{paperID}的考卷資料");
			}
            var paper = _context.TTestPaperBanks.FirstOrDefault(p => p.FTestPaperId == paperID);
            ViewBag.PaperName = paper.FTestPaperName;
            ViewBag.PaperNote = paper.FNote;
            List<CTestPaperViewModel> paperDetail = new List<CTestPaperViewModel>();
            var questionIDInPaper = from t in _context.TTestPapers
                                    where t.FTestPaperId == paperID
                                    select new CTestPaperViewModel
                                    {
                                        fSubjectID = t.FSubjectId,
                                        fQuestionID = t.FQuestionId
                                    };
            foreach(var t in questionIDInPaper)
			{
                paperDetail.Add(t);
			}

            foreach(var q in paperDetail)
			{
				getQuestionFromPaper(q.fSubjectID, q.fQuestionID);
            }
            return View(questionInPaper);
		}
        List<CQuestionBankViewModel> questionInPaper = new List<CQuestionBankViewModel>();
        public void getQuestionFromPaper(string sub,int quesID)
		{
            // TODO:3.想更好的做法
            var quesQuery = from choice in _context.TQuestionDetails
                            join ques in _context.TQuestionLists on new { choice.FSubjectId, choice.FQuestionId } equals new { ques.FSubjectId, ques.FQuestionId }
                            where ques.FSubjectId == sub && ques.FQuestionId == quesID
                            select new CQuestionBankViewModel
                            {
                                FSn = choice.FSn,
                                FCSubjectId = choice.FSubjectId,
                                FSubjectId = ques.FSubjectId,
                                FCQuestionId = choice.FQuestionId,
                                FQuestionId = ques.FQuestionId,
                                FQuestion = ques.FQuestion,
                                FLevel = ques.FLevel,
                                FQuestionTypeId = ques.FQuestionTypeId,
                                FChoice = choice.FChoice,
                                FCorrectAnswer = choice.FCorrectAnswer
                            };
            foreach(var q in quesQuery)
			{
                questionInPaper.Add(q);
			}
		}

        // GET: TTestPaperBanks/Create
        public IActionResult Create()
        {
            ViewBag.Name = CDictionary.username;
            ViewBag.Type = CDictionary.memtype;
            ViewBag.account = CDictionary.account;

            return View();
        }
        public IActionResult DeletePaper(int? paperID)
		{
            if(paperID == null)
			{
                return Content($"查無編號為{paperID}的試卷");
			}
            var paperBank = _context.TTestPaperBanks.FirstOrDefault(t => t.FTestPaperId == paperID);
            var paperDetail = _context.TTestPapers.Where(t => t.FTestPaperId == paperID);
            if(paperBank == null || paperDetail == null)
			{
                return Content($"查無編號為{paperID}的試卷");
            }
            _context.TTestPaperBanks.Remove(paperBank);
            _context.SaveChanges();
            foreach(var q in paperDetail)
			{
                _context.TTestPapers.Remove(q);
			}
            _context.SaveChanges();
            //TODO:4.刪除後不整頁刷新
			return Content("刪除成功", "text/plain", System.Text.Encoding.UTF8);
		}

    }
}
