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
            newpaper.FDesignerAccount = "admin";
            newpaper.FBTestPaperId = 0;
            _context.TTestPaperBanks.Add(newpaper.paperBank);
            _context.SaveChanges();

            // 取得新生成的paperId
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
            // TODO4:迴圈要拆開 There is already an open DataReader associated with this Connection which must be closed first.
            if (/*paperID == null || */paperID == 0)
			{
                return Content($"查無ID為{paperID}的考卷資料");
			}
            var questionIDInPaper = from t in _context.TTestPapers
                                  where t.FTestPaperId == paperID
                                  select t;
            foreach(var q in questionIDInPaper)
			{
                //getQuestionFromPaper(q.FSubjectId, q.FQuestionId);
                var quesQuery = from choice in _context.TQuestionDetails
                                join ques in _context.TQuestionLists on new { choice.FSubjectId, choice.FQuestionId } equals new { ques.FSubjectId, ques.FQuestionId }
                                where ques.FSubjectId == q.FSubjectId && ques.FQuestionId == q.FQuestionId
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
                foreach (var c in quesQuery)
                {
                    questionInPaper.Add(c);
                }
            }
            return View(questionInPaper);
		}
        List<CQuestionBankViewModel> questionInPaper = new List<CQuestionBankViewModel>();
        public void getQuestionFromPaper(string sub,int quesID)
		{
            // TODO3:想更好的做法
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

        // GET: TTestPaperBanks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tTestPaperBank = await _context.TTestPaperBanks
                .FirstOrDefaultAsync(m => m.FTestPaperId == id);
            if (tTestPaperBank == null)
            {
                return NotFound();
            }

            return View(tTestPaperBank);
        }

        // GET: TTestPaperBanks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TTestPaperBanks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("FTestPaperId,FDesignerAccount,FTestPaperName,FSubjectId,FNote")] TTestPaperBank tTestPaperBank)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(tTestPaperBank);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(tTestPaperBank);
        //}

        // GET: TTestPaperBanks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tTestPaperBank = await _context.TTestPaperBanks.FindAsync(id);
            if (tTestPaperBank == null)
            {
                return NotFound();
            }
            return View(tTestPaperBank);
        }

        // POST: TTestPaperBanks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FTestPaperId,FDesignerAccount,FTestPaperName,FSubjectId,FNote")] TTestPaperBank tTestPaperBank)
        {
            if (id != tTestPaperBank.FTestPaperId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tTestPaperBank);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TTestPaperBankExists(tTestPaperBank.FTestPaperId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tTestPaperBank);
        }

        // GET: TTestPaperBanks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tTestPaperBank = await _context.TTestPaperBanks
                .FirstOrDefaultAsync(m => m.FTestPaperId == id);
            if (tTestPaperBank == null)
            {
                return NotFound();
            }

            return View(tTestPaperBank);
        }

        // POST: TTestPaperBanks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tTestPaperBank = await _context.TTestPaperBanks.FindAsync(id);
            _context.TTestPaperBanks.Remove(tTestPaperBank);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TTestPaperBankExists(int id)
        {
            return _context.TTestPaperBanks.Any(e => e.FTestPaperId == id);
        }
    }
}
