using Microsoft.AspNetCore.Mvc;
using MSITTeam1.Models;
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
			return View(_context.TQuestionLists.ToList());
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
				if (ques != null)
				{
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
