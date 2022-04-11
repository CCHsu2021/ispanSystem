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

		public IActionResult List()
		{
			List<CQuestionBankViewModel> quesList = new List<CQuestionBankViewModel>();
			var quesQuery = from choice in _context.TQuestionDetails
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
			foreach (var q in quesQuery)
			{
				quesList.Add(q);
			}

			return View(quesList);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create([Bind("FSn,FSubjectId,FCSubjectId,FQuestionId,FCQuestionId,FQuestion,FChoice,FLevel,FCorrectAnswer,FQuestionTypeId")] CQuestionBankViewModel ques)
		{
			TQuestionList quesQuery = _context.TQuestionLists.FirstOrDefault(q => q.FSubjectId.Equals(ques.FSubjectId));
			if(quesQuery == null)
			{
				ques.FQuestionId = 1;
				ques.FCQuestionId = 1;
			}
			else
			{
				var searchLastId = from q in _context.TQuestionLists
								   where q.FSubjectId.Equals(ques.FSubjectId)
								   orderby q.FQuestionId descending
								   select q;

				int lastId = searchLastId.First().FQuestionId;
				ques.FQuestionId = lastId + 1;
				//ques.FCQuestionId = lastId + 1;
			}
			_context.TQuestionLists.Add(ques.question);
			ques.FCSubjectId = ques.FSubjectId;
			ques.FCQuestionId = ques.FQuestionId;
			_context.TQuestionDetails.Add(ques.choice);
			_context.SaveChanges();
			return RedirectToAction("List");
		}
		public IActionResult Edit(string subjectID, int questionID,int choiceSn)
		{
			// TODO-1:可以一次編輯此題的所有選項和選擇正確選項
			// TODO-2:加入題型判斷
			if (subjectID != null && questionID > 0)
			{
				TQuestionList ques = _context.TQuestionLists.FirstOrDefault(q => q.FSubjectId.Equals(subjectID) && q.FQuestionId == questionID);
				//var cho = _context.TQuestionDetails.Where(c => c.FSubjectId.Equals(subjectID) && c.FQuestionId == questionID);
				TQuestionDetail cho = _context.TQuestionDetails.FirstOrDefault(c => c.FSn == choiceSn);
				if (ques != null && cho != null)
				{
					return View(new CQuestionBankViewModel() { question = ques,choice = cho});
				}
			}
			return RedirectToAction("List");
		}

		[HttpPost]
		public IActionResult Edit(CQuestionBankViewModel ques)
		{
			TQuestionList quesSel = _context.TQuestionLists.FirstOrDefault(q => q.FSubjectId.Equals(ques.FSubjectId) && q.FQuestionId == ques.FQuestionId);
			TQuestionDetail choSel = _context.TQuestionDetails.FirstOrDefault(c => c.FSn == ques.FSn);
			if (quesSel != null)
			{
				quesSel.FQuestion = ques.FQuestion;
				quesSel.FQuestionTypeId = Convert.ToInt32(ques.FQuestionTypeId);
				choSel.FChoice = ques.FChoice;
				choSel.FCorrectAnswer = ques.FCorrectAnswer;
				_context.SaveChanges();
			}
			return RedirectToAction("List");
		}
	}
}
