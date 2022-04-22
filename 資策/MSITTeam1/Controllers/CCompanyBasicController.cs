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
            IEnumerable<TCompanyBasic> com = null;
            com = hello.TCompanyBasics.Where(t => t.CompanyTaxid == taxid);
            List<CCompanyBasicViewModel> list = new List<CCompanyBasicViewModel>();
            foreach (TCompanyBasic t in com)
            {
                if (t.FLogo == null)
                {
                    ViewBag.picture = "upload.png";
                }
                else
                {
                    ViewBag.picture = t.FLogo;
                }
                list.Add(new CCompanyBasicViewModel() { com = t });
            }
            return View(list);
        }
    }
}
