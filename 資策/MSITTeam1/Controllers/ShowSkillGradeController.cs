using Microsoft.AspNetCore.Mvc;
using MSITTeam1.Models;
using MSITTeam1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.Controllers
{
    public class ShowSkillGradeController : Controller
    {
        private readonly helloContext hello;
        public ShowSkillGradeController(helloContext _hello)
        {
            hello = _hello;
        }
        public IActionResult Index(GradeIdentify Grade)
        {
            ViewBag.skillname = "";
            var account = hello.StudentBasics.FirstOrDefault(c => c.MemberId == CDictionary.account);
            if (account != null)
                ViewBag.Account = account.FAccount;
            if (CDictionary.account != null)
            {
                if (Grade.txtidentify != null)
                {
                    var skillcate = from b in hello.TSkillGrades
                                    where b.FAccount == account.FAccount
                                    select b;
                    ViewBag.Identify = Grade.txtidentify;
                    var maxcount = 0;
                    TSkillGrade self = hello.TSkillGrades.FirstOrDefault(c => c.FAccount == account.FAccount && c.FSkillCategory == Grade.txtidentify);
                    if (self != null)
                    {
                        ViewBag.skillname = self.FSkillCategory;
                        ViewBag.showself = self.FGrade;
                        int list = 0;
                        for (int i = 5; i <= 100; i += 10)
                        {
                            list = (from p in hello.TSkillGrades
                                    where p.FSkillCategory == Grade.txtidentify && p.FGrade > (i - 5) && p.FGrade <= (i + 5)
                                    select p).Count();
                            if (maxcount < list)
                                maxcount = list;
                            if (i == 95)
                                ViewBag.show += list + "";
                            else
                                ViewBag.show += list + ",";
                        }
                    }
                    if (maxcount < 5)
                        maxcount = 5;
                    ViewBag.count = maxcount;
                    return View(skillcate);
                }
                else
                {
                    var skillcate = from b in hello.TSkillGrades
                                    where b.FAccount == account.FAccount
                                    select b;
                    ViewBag.count = 1;
                    return View(skillcate);
                }
            }
             else
                {
                return RedirectToAction("Index", "Student_Login");
            }
        }
    }
}
