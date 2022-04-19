using Microsoft.AspNetCore.Mvc;
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
	public class QuestionBankCreateViewComponent:Microsoft.AspNetCore.Mvc.ViewComponent
	{
		private readonly helloContext _context;

		[ActivatorUtilitiesConstructor]
		public QuestionBankCreateViewComponent(helloContext context)
		{
			_context = context;
		}

		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
