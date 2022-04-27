using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MSITTeam1.Models;
using MSITTeam1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.Controllers
{
	public class QuestionBankController : Controller
	{
		private readonly helloContext _context;
		public QuestionBankController(helloContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult List()
		{
			return View();
		}
		[HttpPost]
		public IActionResult List([FromBody]CQuestionQueryViewModel query)
		{
			ViewBag.Name = CDictionary.username;
			ViewBag.Type = CDictionary.memtype;
			ViewBag.account = CDictionary.account;

			return ViewComponent("QuestionBankList", new { keyword = query.keyword, Subjects = query.Subjects, Type = query.Type });
		}
		private IQueryable<CQuestionBankViewModel> FilterByType(IQueryable<CQuestionBankViewModel> table, string level)
		{
			if (!string.IsNullOrEmpty(level))
			{
				int tempLevel = int.Parse(level);
				return table.Where(q => q.FLevel == tempLevel);
			}
			else
			{
				return table;
			}
		}

		private IQueryable<CQuestionBankViewModel> FilterByKeyWord(IQueryable<CQuestionBankViewModel> table, string keyword)
		{
			if (!string.IsNullOrEmpty(keyword))
			{
				return table.Where(q =>
						q.FQuestion.Contains(keyword)
						|| q.FChoice.Contains(keyword)
						|| q.FSubjectId.Contains(keyword));
			}
			else
			{
				return table;
			}
		}

		private IQueryable<CQuestionBankViewModel> FilterByClass(IQueryable<CQuestionBankViewModel> table,string className)
		{
			if (!string.IsNullOrEmpty(className))
			{
				return table.Where(q => q.FSubjectId.Trim().Equals(className.Trim()));
			}
			else
			{
				return table;
			}
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create([FromBody] CQuestionBankViewModel newques)
		{
			TQuestionList quesQuery = _context.TQuestionLists.FirstOrDefault(q => q.FSubjectId.Equals(newques.FSubjectId));
			if (quesQuery == null)
			{
				newques.FQuestionId = 1;
				newques.FCQuestionId = 1;
			}
			else
			{
				var searchLastId = from q in _context.TQuestionLists
								   where q.FSubjectId.Equals(newques.FSubjectId)
								   orderby q.FQuestionId descending
								   select q;

				int lastId = searchLastId.First().FQuestionId;
				newques.FQuestionId = lastId + 1;
			}
			newques.FSubmitterId = "測試";
			newques.FState = 0;
			_context.TQuestionLists.Add(newques.question);
			foreach (var ans in newques.FChoiceList)
			{
				newques.FCSubjectId = newques.FSubjectId;
				newques.FCQuestionId = newques.FQuestionId;
				newques.FChoice = ans.Fchoice;
				newques.FCorrectAnswer = ans.FCorrect;
				newques.FSn = 0;
				_context.TQuestionDetails.Add(newques.choice);
				_context.SaveChanges();
			}
			_context.SaveChanges();
			return Content("新增成功");
		}
		public IActionResult Edit(string subjectID, int questionID)
		{
			if (subjectID != null && questionID > 0)
			{
				List<CQuestionBankViewModel> quesList = new List<CQuestionBankViewModel>();
				var quesQuery = from choice in _context.TQuestionDetails
								join ques in _context.TQuestionLists on new { choice.FSubjectId, choice.FQuestionId } equals new { ques.FSubjectId, ques.FQuestionId }
								where choice.FSubjectId.Equals(subjectID) && choice.FQuestionId == questionID
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

				foreach (var q in quesQuery)
				{
					quesList.Add(q);
				}
				if (quesList != null)
				{
					return View(quesList);
				}
			}
			return RedirectToAction("List");
		}

		[HttpPost]
		public IActionResult Edit([FromBody] CQuestionBankViewModel quesList)
		{
			 if (quesList != null)
			{
				string subject = quesList.FSubjectId;
				int questionId = quesList.FQuestionId;

				TQuestionList quesSel = _context.TQuestionLists.FirstOrDefault(q => q.FSubjectId.Equals(subject) && q.FQuestionId == questionId);
				TQuestionDetail choSel = null;
				if (quesSel != null)
				{
					quesSel.FQuestion = quesList.FQuestion;
					quesSel.FQuestionTypeId = Convert.ToInt32(quesList.FQuestionTypeId);
					_context.SaveChanges();
					foreach (var ans in quesList.FChoiceList)
					{
						if(ans.FSN != 0)
						{
						choSel = _context.TQuestionDetails.FirstOrDefault(c => c.FSn == ans.FSN);
						choSel.FChoice = ans.Fchoice;
						choSel.FCorrectAnswer = ans.FCorrect;
						_context.SaveChanges();
						}
						else
						{
							quesList.FCSubjectId = quesList.FSubjectId;
							quesList.FCQuestionId = quesList.FQuestionId;
							quesList.FChoice = ans.Fchoice;
							quesList.FCorrectAnswer = ans.FCorrect;
							quesList.FSn = 0;
							_context.TQuestionDetails.Add(quesList.choice);
							_context.SaveChanges();
						}
					}
				}
			}
			return RedirectToAction("List");
		}

		public IActionResult Delete(string subjectID, int questionID)
		{
			if (subjectID != null && questionID > 0)
			{
				var ques = _context.TQuestionLists.FirstOrDefault(q => q.FSubjectId.Equals(subjectID) && q.FQuestionId == questionID);
				if (ques != null)
				{
					ques.FState = 0;
					_context.SaveChanges();
				}
			}
			return RedirectToAction("List");
		}

		public IActionResult Subject()
		{
			var subjects = _context.TStudioInformations.Select(s => new
			{
				s.FClassCategory
			}).Distinct().OrderBy(s => s.FClassCategory);
			return Json(subjects);
		}

		public IActionResult Classes()
		{
			var subjects = _context.TStudioInformations.Select(s => new
			{
				s.FClassSkill
			}).Distinct().OrderBy(s => s.FClassSkill);
			return Json(subjects);
		}
	}
}
