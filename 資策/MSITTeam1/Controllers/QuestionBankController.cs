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
								FCSubjectId = ques.FSubjectId,
								FCQuestionId = ques.FQuestionId,
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
		public IActionResult Create([Bind("FSubjectId,FQuestionId,FQuestion,FChoice,FLevel,FCorrectAnswer,FQuestionTypeId")] CQuestionBankViewModel ques)
		{
			//_context.TQuestionLists.Add(ques.question);
			_context.TQuestionDetails.Add(ques.choice);
			_context.SaveChanges();
			return RedirectToAction("List");
		}
		public IActionResult Edit(string subjectID, int questionID,string choice)
		{
			if (subjectID != null && questionID > 0)
			{
				TQuestionList ques = _context.TQuestionLists.FirstOrDefault(q => q.FSubjectId.Equals(subjectID) && q.FQuestionId == questionID);
				//var cho = _context.TQuestionDetails.Where(c => c.FSubjectId.Equals(subjectID) && c.FQuestionId == questionID);
				TQuestionDetail cho = _context.TQuestionDetails.FirstOrDefault(c => c.FSubjectId.Equals(subjectID) && c.FQuestionId == questionID && c.FChoice == choice);
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
			TQuestionDetail choSel = _context.TQuestionDetails.FirstOrDefault(c => c.FSubjectId.Equals(ques.FSubjectId) && c.FQuestionId == ques.FQuestionId && c.FChoice == ques.FChoice);
			if (quesSel != null)
			{
				//quesSel.FQuestion = ques.FQuestion;
				//quesSel.FQuestionTypeId = Convert.ToInt32(ques.FQuestionTypeId);
				choSel.FChoice = ques.FChoice;
				_context.SaveChanges();
			}
			return RedirectToAction("List");
		}
	}
}
