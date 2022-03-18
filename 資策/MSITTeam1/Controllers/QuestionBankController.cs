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
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult List()
		{
			IEnumerable<TChoiceQuestion> ques = from q in (new helloContext()).TChoiceQuestions
																			 select q;			

			return View(ques);
		}
	}
}
