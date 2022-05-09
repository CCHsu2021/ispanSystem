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
    public class StudentController : Controller
    {
        private readonly helloContext hello;

        public StudentController(helloContext _hello)
        {
            hello = _hello;
        }
        public IActionResult Information()
        {
            string account = HttpContext.Session.GetString(CDictionary.SK_LOGINED_USER_ACCOUNT);
            ViewBag.Account = account;
            IEnumerable<StudentBasic> stu = null;
            stu = hello.StudentBasics.Where(t => t.FAccount == "111");
            List<CStudentBasicViewModel> list = new List<CStudentBasicViewModel>();
            foreach (StudentBasic t in stu)
            {
                list.Add(new CStudentBasicViewModel() { stu = t });
            }
            return PartialView("Information", list);
        }

        public IActionResult StudentInformationEdit(string account = "111")
        {
            if (!string.IsNullOrEmpty(account))
            {
                //helloContext hello = new helloContext();
                var student = hello.StudentBasics.FirstOrDefault(p => p.FAccount == account);
                if (student != null)
                    return View(new CStudentBasicViewModel() { stu = student });
            }
            return RedirectToAction("Information");
        }

    }
}
