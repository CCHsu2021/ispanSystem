using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSITTeam1.Models;
using MSITTeam1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.Controllers
{
    public class CMemberCenterController : Controller
    {
        private readonly helloContext hello;

        public CMemberCenterController(helloContext _hello)
        {
            hello = _hello;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CompanyInformationEdit(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var company = hello.TCompanyBasics.FirstOrDefault(p => p.FAccount == id);
                if (company != null)
                    return PartialView(new CCompanyBasicViewModel() { com = company });
            }
            return RedirectToAction("Index");
        }
    }
}
