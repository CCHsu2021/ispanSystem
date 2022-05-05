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
	public class QuestionBankCreateAdViewComponent:Microsoft.AspNetCore.Mvc.ViewComponent
	{
		private readonly helloContext _context;

		[ActivatorUtilitiesConstructor]
		public QuestionBankCreateAdViewComponent(helloContext context)
		{
			_context = context;
		}

		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
