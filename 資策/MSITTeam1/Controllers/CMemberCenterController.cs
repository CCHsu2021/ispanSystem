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
        public IActionResult Index()
        {
            string account = HttpContext.Session.GetString(CDictionary.SK_LOGINED_USER_ACCOUNT);
            IEnumerable<TCompanyBasic> com = null;
            com = hello.TCompanyBasics.Where(t => t.FAccount == "company1");
            List<CCompanyBasicViewModel> list = new List<CCompanyBasicViewModel>();
            foreach (TCompanyBasic t in com)
            {
                list.Add(new CCompanyBasicViewModel() { com = t });
            }
            ViewBag.Name = CDictionary.username;
            return View(list);
        }
        public IActionResult CompanyInformation()
        {
            string account = HttpContext.Session.GetString(CDictionary.SK_LOGINED_USER_ACCOUNT);
            IEnumerable<TCompanyBasic> com = null;
            com = hello.TCompanyBasics.Where(t => t.FAccount == account);
            List<CCompanyBasicViewModel> list = new List<CCompanyBasicViewModel>();
            foreach (TCompanyBasic t in com)
            {
                list.Add(new CCompanyBasicViewModel() { com = t });
            }
            ViewBag.Name = CDictionary.username;
            return View(list);
        }

        private readonly helloContext hello;

        public CMemberCenterController(helloContext _hello)
        {
            hello = _hello;
        }
        public IActionResult StudentInformationEdit(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                //helloContext hello = new helloContext();
                var student = hello.StudentBasics.FirstOrDefault(p => p.FAccount == id);
                if (student != null)
                    return PartialView(new CStudentBasicViewModel() { stu = student });
            }
            return RedirectToAction("Index");
        }

    }
}
