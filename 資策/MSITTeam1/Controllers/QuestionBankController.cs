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
		public IActionResult List(string keyword,string Subjects,string Type)
		{
			// 從資料庫讀取題目
			List<CQuestionBankViewModel> quesList = new List<CQuestionBankViewModel>();
			IQueryable<CQuestionBankViewModel> quesQuery = from choice in _context.TQuestionDetails
							join ques in _context.TQuestionLists on new { choice.FSubjectId, choice.FQuestionId } equals new { ques.FSubjectId, ques.FQuestionId }
							select new CQuestionBankViewModel
							{
								FSn = choice.FSn,
								FCSubjectId = choice.FSubjectId,
								FSubjectId = ques.FSubjectId,
								FCQuestionId = choice.FQuestionId,
								FQuestionId = ques.FQuestionId,
								FQuestion = ques.FQuestion,
								FLevel = ques.FLevel,
								//updateTime = ques.FUpdateTime.ToString('YYMMDD'),
								FQuestionTypeId = ques.FQuestionTypeId,
								FChoice = choice.FChoice,
								FCorrectAnswer = choice.FCorrectAnswer
							};
			// DropDownList - 課程			
			List<SelectListItem> subjectItems = new List<SelectListItem>();
			string temp = "";
			foreach(var s in quesQuery)
			{
				if(s.FSubjectId.Trim() != temp)
				{
					subjectItems.Add(new SelectListItem()
					{
						Text = s.FCSubjectId
					});
				}
				temp = s.FSubjectId.Trim();
			}			
			// DropDownList - 題型			
			List<SelectListItem> typeItems = new List<SelectListItem>();
			typeItems.Add(new SelectListItem()
			{
				Text = "單選題",
				Value = "1"
			}); 
			typeItems.Add(new SelectListItem()
			{
				Text = "多選題",
				Value = "2"
			}); 
			typeItems.Add(new SelectListItem()
			{
				Text = "填空題",
				Value = "3"
			});
			ViewBag.Subjects = subjectItems;
			ViewBag.Type = typeItems;

			// 篩選題目
			quesQuery = this.FilterByClass(quesQuery, Subjects);
			quesQuery = this.FilterByKeyWork(quesQuery, keyword);
			quesQuery = this.FilterByLevel(quesQuery, Type);
			
			foreach (var q in quesQuery)
				{
					quesList.Add(q);
				}
				return View(quesList);
		}
		private IQueryable<CQuestionBankViewModel> FilterByLevel(IQueryable<CQuestionBankViewModel> table, string level)
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

		private IQueryable<CQuestionBankViewModel> FilterByKeyWork(IQueryable<CQuestionBankViewModel> table, string keyword)
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
			// TODO-2:加入題型判斷

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

				List<SelectListItem> subjectItems = new List<SelectListItem>();
				var subjectQuery = from s in _context.TStudioInformations
								   select s;
				foreach(var s in subjectQuery)
				{
					subjectItems.Add(new SelectListItem()
					{
						Text = s.FClassSkill,
						Value = s.FClassSkill
					}) ;
				}

				List<SelectListItem> typeItems = new List<SelectListItem>();
				typeItems.Add(new SelectListItem()
				{
					Text = "單選題",
					Value = "1"
				});
				typeItems.Add(new SelectListItem()
				{
					Text = "多選題",
					Value = "2"
				});
				typeItems.Add(new SelectListItem()
				{
					Text = "填空題",
					Value = "3"
				});

				ViewBag.Subjects = subjectItems;
				ViewBag.Type = typeItems;

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
						//choSel = _context.TQuestionDetails.FirstOrDefault(c => c.FSn == ans.FSn);
						//choSel.FChoice = ans.FChoice;
						//choSel.FCorrectAnswer = ans.FCorrectAnswer;
						//TODO3:savechange不要放在迴圈
						_context.SaveChanges();
					}
				}
			}
			return RedirectToAction("List");
		}
	}
}
