using Microsoft.AspNetCore.Mvc;
using MSITTeam1.Models;
using MSITTeam1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.Controllers
{
    public class CCompanyBasicController : Controller
    {
        private readonly helloContext hello;

        public CCompanyBasicController(helloContext _hello)
        {
            hello = _hello;
        }
        public IActionResult Index(string taxid)
        {
            TCompanyBasic company = hello.TCompanyBasics.FirstOrDefault(p => p.CompanyTaxid == taxid);           
            return View(new CCompanyBasicViewModel() { com = company});
        }
    }
}
