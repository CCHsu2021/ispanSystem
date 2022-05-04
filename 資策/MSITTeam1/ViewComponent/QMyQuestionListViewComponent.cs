using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using MSITTeam1.Models;
using MSITTeam1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MSITTeam1.ViewComponent
{
	[Microsoft.AspNetCore.Mvc.ViewComponent]
	public class QMyQuestionListViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
	{
		private readonly helloContext _context;

		[ActivatorUtilitiesConstructor]
		public QMyQuestionListViewComponent(helloContext context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			ViewBag.Name = CDictionary.username;
			ViewBag.Type = CDictionary.memtype;
			ViewBag.account = CDictionary.account;

			// 從資料庫讀取題目
			List<CQuestionBankViewModel> quesList = new List<CQuestionBankViewModel>();
			IQueryable<CQuestionBankViewModel> quesQuery = from choice in _context.TQuestionDetails
														   join ques in _context.TQuestionLists on new { choice.FSubjectId, choice.FQuestionId } equals new { ques.FSubjectId, ques.FQuestionId }
														   where ques.FSubmitterId == CDictionary.account
														   //where ques.FSubmitterId == "222"
														   orderby ques.FSubjectId
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
			// 篩選題目

			foreach (var q in quesQuery)
			{
				quesList.Add(q);
			}
			return View(quesList);
		}
	}
}
