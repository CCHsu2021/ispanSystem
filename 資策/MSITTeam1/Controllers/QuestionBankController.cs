using Microsoft.AspNetCore.Mvc;
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
	}
}

Scaffold - DbContext "Data Source=msit40.database.windows.net;Initial Catalog=hello;User ID=MSIT40;Password=Ispan40team1" Microsoft.EntityFrameworkCore.SqlServer - OutputDir Models -Force