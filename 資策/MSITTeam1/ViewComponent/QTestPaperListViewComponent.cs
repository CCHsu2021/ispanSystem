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
	public class QTestPaperListViewComponent: Microsoft.AspNetCore.Mvc.ViewComponent
	{
		private readonly helloContext _context;
		[ActivatorUtilitiesConstructor]
		public QTestPaperListViewComponent(helloContext context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			//TODO:5.檢查有沒有取得會員資料
			ViewBag.Name = CDictionary.username;
			ViewBag.Type = CDictionary.memtype;
			ViewBag.account = CDictionary.account;

			List<CTestPaperBankViewModel> paperList = new List<CTestPaperBankViewModel>();
			var paperQuery = from t in _context.TTestPaperBanks
							 where t.FDesignerAccount == CDictionary.account || t.FDesignerAccount == "admin"
							 select new CTestPaperBankViewModel
							 {
								 FTestPaperName = t.FTestPaperName,
								 FTestPaperId = t.FTestPaperId,
								 FDesignerAccount = t.FDesignerAccount,
								 FBSubjectId = t.FSubjectId,
								 FNote = t.FNote
							 };
			foreach (var t in paperQuery)
			{
				paperList.Add(t);
			}

			return View(paperList);
		}
	}
}
