using Microsoft.AspNetCore.Mvc;
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
		public IActionResult List(string keyword,string subject,string level)
		{
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
			//if (!string.IsNullOrEmpty(keyword))
			//{
			//	var showList = quesQuery.Where(q =>
			//	q.FSubjectId.Contains(keyword) ||
			//	q.FQuestion.Contains(keyword) ||
			//	q.FChoice.Contains(keyword));

			quesQuery = this.FilterByClass(quesQuery, subject);
			quesQuery = this.FilterByKeyWork(quesQuery, keyword);
			quesQuery = this.FilterByLevel(quesQuery, level);

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
				// return all
				return table;
			}
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create([Bind("FSn,FSubjectId,FCSubjectId,FQuestionId,FCQuestionId,FQuestion,FChoice,FLevel,FCorrectAnswer,FQuestionTypeId")] List<CQuestionBankViewModel> newques)
		{
			TQuestionList quesQuery = _context.TQuestionLists.FirstOrDefault(q => q.FSubjectId.Equals(newques[0].FSubjectId));
			if(quesQuery == null)
			{
				newques[0].FQuestionId = 1;
				newques[0].FCQuestionId = 1;
			}
			else
			{
				var searchLastId = from q in _context.TQuestionLists
								   where q.FSubjectId.Equals(newques[0].FSubjectId)
								   orderby q.FQuestionId descending
								   select q;

				int lastId = searchLastId.First().FQuestionId;
				newques[0].FQuestionId = lastId + 1;
			}
			_context.TQuestionLists.Add(newques[0].question);
			//foreach (var c in newques)
			//{
			//	newques[i].FCSubjectId = newques[0].FSubjectId;
			//	newques[i].FCQuestionId = newques[0].FQuestionId;
			//	_context.TQuestionDetails.Add(newques[i].choice);
			//}
			_context.SaveChanges();
			return RedirectToAction("List");
		}
		public IActionResult Edit(string subjectID, int questionID)
		{
			// TODO-1:可以一次編輯此題的所有選項和選擇正確選項
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
									//updateTime = ques.FUpdateTime.ToString('YYMMDD'),
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
		public IActionResult Edit(List<CQuestionBankViewModel> quesList)
		{
			if (quesList.Count != 0)
			{
				string subject = quesList[0].FSubjectId;
				int questionId = quesList[0].FQuestionId;

				TQuestionList quesSel = _context.TQuestionLists.FirstOrDefault(q => q.FSubjectId.Equals(subject) && q.FQuestionId == questionId);
				TQuestionDetail choSel = null;
				if (quesSel != null)
				{
					quesSel.FQuestion = quesList[0].FQuestion;
					quesSel.FQuestionTypeId = Convert.ToInt32(quesList[0].FQuestionTypeId);
					_context.SaveChanges();
					foreach (var ans in quesList)
					{
						choSel = _context.TQuestionDetails.FirstOrDefault(c => c.FSn == ans.FSn);
						choSel.FChoice = ans.FChoice;
						choSel.FCorrectAnswer = ans.FCorrectAnswer;
						// TODO3:savechange不要放在迴圈
						_context.SaveChanges();
					}
				}
				return RedirectToAction("List");
			}
			else
			{
				return Content("HIAHIAHIAHIAHIA");
			}
		}
	}
}
