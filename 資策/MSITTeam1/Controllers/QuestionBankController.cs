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
								Vsubject = ques.FSubjectId,
								VquestionId = ques.FQuestionId,
								Vquestion = ques.FQuestion,
								Vlevel = ques.FLevel,
								//updateTime = ques.FUpdateTime.ToString('YYMMDD'),
								VquestionType = ques.FQuestionTypeId,
								Vchoice = choice.FChoice,
								VcorrectAnswer = choice.FCorrectAnswer
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

		//[HttpPost]
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
				
				TQuestionDetail cho = _context.TQuestionDetails.FirstOrDefault(c => c.FSubjectId.Equals(subjectID) && c.FQuestionId == questionID);
				List<CQuestionBankViewModel> temp = null;
				if (ques != null)
				{
					//IQueryable<CQuestionBankViewModel> selectQues = from choice in _context.TQuestionDetails
					//												join q in _context.TQuestionLists on new { choice.FSubjectId, choice.FQuestionId }
					//												equals new { q.FSubjectId, q.FQuestionId }
					//												select new CQuestionBankViewModel
					//												{
					//													Vsubject = q.FSubjectId,
					//													VquestionId = q.FQuestionId,
					//													Vquestion = q.FQuestion,
					//													Vchoice = choice.FChoice
					//												};
					//foreach (var q in selectQues)
					//{
					//	temp.Add(q);
					//}

					return View(new CQuestionBankViewModel() { question = ques , choice = cho});
					//return View(ques);
				}
			}
			return RedirectToAction("List");
		}

		[HttpPost]
		public IActionResult Edit(CQuestionBankViewModel ques)
		{
			TQuestionList quesSel = _context.TQuestionLists.FirstOrDefault(q => q.FSubjectId.Equals(ques.Vsubject) && q.FQuestionId == ques.VquestionId);
			if (quesSel != null)
			{
				quesSel.FQuestion = ques.Vquestion;
				quesSel.FQuestionTypeId = Convert.ToInt32(ques.VquestionType);
				_context.SaveChanges();
			}
			return RedirectToAction("List");
		}
	}
}
