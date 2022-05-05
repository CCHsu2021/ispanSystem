using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using MSITTeam1Admin.Models;
using MSITTeam1Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MSITTeam1Admin.ViewComponent
{
	[Microsoft.AspNetCore.Mvc.ViewComponent]
	public class QDelQuestionListViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
	{
		private readonly helloContext _context;

		[ActivatorUtilitiesConstructor]
		public QDelQuestionListViewComponent(helloContext context)
		{
			_context = context;
		}
		public IViewComponentResult Invoke()
		{
			// 從資料庫讀取題目
			List<CQuestionBankViewModel> quesList = new List<CQuestionBankViewModel>();
			IQueryable<CQuestionBankViewModel> quesQuery = from choice in _context.TQuestionDetails
														   join ques in _context.TQuestionLists on new { choice.FSubjectId, choice.FQuestionId } equals new { ques.FSubjectId, ques.FQuestionId }
														   where ques.FState == 0
														   orderby ques.FSubjectId
														   select new CQuestionBankViewModel
														   {
															   FSn = choice.FSn,
															   FCSubjectId = choice.FSubjectId,
															   FSubjectId = ques.FSubjectId,
															   FCQuestionId = choice.FQuestionId,
															   FQuestionId = ques.FQuestionId,
															   FQuestion = ques.FQuestion,
															   FState = ques.FState,
															   FLevel = ques.FLevel,
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
	}
}
