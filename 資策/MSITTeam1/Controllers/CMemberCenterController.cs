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
            ViewBag.Name = CDictionary.username;
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

        [HttpPost]
        public IActionResult CompanyInformationEdit(CCompanyBasicViewModel company)
        {
            TCompanyBasic c = hello.TCompanyBasics.FirstOrDefault(p => p.FAccount == company.FAccount);
            if(c != null)
            {
                c.FAddress = company.FAddress;
                c.FCity = company.FCity;
                c.FDistrict = company.FDistrict;
                c.FEmail = company.FEmail;
                c.FFaxCode = company.FFaxCode;
                c.FFax = company.FFax;
                c.FPhoneCode = company.FPhoneCode;
                c.FPhone = company.FPhone;
                hello.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
