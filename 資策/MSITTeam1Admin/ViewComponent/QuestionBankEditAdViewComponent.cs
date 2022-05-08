using Microsoft.AspNetCore.Mvc;
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
	public class QuestionBankEditAdViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
	{
		private readonly helloContext _context;

		[ActivatorUtilitiesConstructor]
		public QuestionBankEditAdViewComponent(helloContext context)
		{
			_context = context;
		}

		public IViewComponentResult Invoke(string subjectID,int questionID)
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
									FState = ques.FState,
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
			return Content("查無資料");
		}
	}
}
