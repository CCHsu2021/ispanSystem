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
			var quesList = from choice in _context.TQuestionDetails
					   join ques in _context.TQuestionLists on new { choice.FSubjectId, choice.FQuestionId } equals new { ques.FSubjectId, ques.FQuestionId }
					   select new CQuestionBankViewModel
					   {
						   subject = ques.FSubjectId,
						   questionId = ques.FQuestionId,
						   question = ques.FQuestion,
						   level = ques.FLevel,
						   //updateTime = ques.FUpdateTime.ToString('YYMMDD'),
						   questionType = ques.FQuestionTypeId.ToString(),
						   choice = choice.FChoice,
						   correctAnswer = choice.FCorrectAnswer
					   };

			return View(quesList.ToList());
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		//public IActionResult Create()
		//{
		//	_context.TQuestionLists.Add
		//	return View();
		//}
		public IActionResult Edit(string subjectID, int questionID)
		{
			if (subjectID != null && questionID > 0)
			{
				TQuestionList ques = _context.TQuestionLists.FirstOrDefault(q => q.FSubjectId.Equals(subjectID) && q.FQuestionId == questionID);
				//List<CQuestionBankViewModel> temp = null;
				if (ques != null)
				{
					//	IQueryable<CQuestionBankViewModel> selectQues = from choice in _context.TQuestionDetails
					//					 join q in _context.TQuestionLists on new { choice.FSubjectId, choice.FQuestionId }
					//					 equals new { q.FSubjectId, q.FQuestionId }
					//					 select new CQuestionBankViewModel
					//					 {
					//						 subject = q.FSubjectId,
					//						 questionId = q.FQuestionId,
					//						 question = q.FQuestion,
					//						 choice = choice.FChoice
					//					 };
					//	foreach(var q in selectQues)
					//	{
					//		temp.Add(q);
					//	}
					return View(ques);
				}
			}
			return RedirectToAction("List");
		}

		[HttpPost]
		public IActionResult Edit(TQuestionList ques)
		{
			TQuestionList quesSel = _context.TQuestionLists.FirstOrDefault(q => q.FSubjectId.Equals(ques.FSubjectId) && q.FQuestionId == ques.FQuestionId);
			if (quesSel != null)
			{
				quesSel.FQuestion = ques.FQuestion;
				quesSel.FQuestionTypeId = ques.FQuestionTypeId;
				_context.SaveChanges();
			}
			return RedirectToAction("List");
		}
	}
}
