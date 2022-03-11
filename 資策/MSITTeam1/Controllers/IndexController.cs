using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSITTeam1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.Controllers
{
    public class IndexController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Name = "";
            string account = "";
            string type = "";
            if (HttpContext.Session.Keys.Contains(CDictionary.SK_LOGINED_USER_ACCOUNT))
            {
               account = HttpContext.Session.GetString(CDictionary.SK_LOGINED_USER_ACCOUNT);
               type = HttpContext.Session.GetString(CDictionary.SK_LOGINED_USER_MEMBERTYPE);
                helloContext hello = new helloContext();
                if (type == "1")
                {
                    StudentBasic stu = hello.StudentBasics.FirstOrDefault(p => p.FAccount == account);
                    ViewBag.Name = stu.Name;
                }
                else if (type == "2")
                {
                    TCompanyBasic com = hello.TCompanyBasics.FirstOrDefault(p => p.FAccount == account);
                    ViewBag.Name = com.FName;
                }
            }

            return View();
        }
    }
}
