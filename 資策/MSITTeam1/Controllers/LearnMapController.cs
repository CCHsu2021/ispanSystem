using Microsoft.AspNetCore.Mvc;
using MSITTeam1.Models;
using MSITTeam1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.Controllers
{

    public class LearnMapController : Controller
    {
        private readonly helloContext hello;
        public LearnMapController(helloContext _hello)
        {
            hello = _hello;
        }
        public IActionResult Index(selectMap a)
        {
            if (a.selectmap == null)
            {
                ViewBag.classmap = "所有課程";
                LearnMap LearnMap = new LearnMap();
                var list = from c in hello.TStudioInformations
                           orderby c.FClassName, c.FClassCategory
                           select c;
                LearnMap.TStudioInformationleft = list.ToList();
                var list2 = from c in hello.TStudioInformations
                            orderby c.FClassName, c.FClassCategory
                            select c;
                LearnMap.TStudioInformationright = list2.ToList();

                return View(LearnMap);
            }
            else
            {
                ViewBag.classmap = a.selectmap;
                LearnMap LearnMap = new LearnMap();
                var list = from c in hello.TStudioInformations
                           orderby c.FClassName, c.FClassCategory
                           where c.FClassName == a.selectmap
                           select c;
                LearnMap.TStudioInformationleft = list.ToList();
                var list2 = from c in hello.TStudioInformations
                            orderby c.FClassName, c.FClassCategory
                            select c;
                LearnMap.TStudioInformationright = list2.ToList();
                return View(LearnMap);
            }
        }
        public IActionResult skill(selectMap s)
        {
            if (s.selectmap != null)
            {
                var list = from c in hello.TStudioInformations
                           orderby c.FClassName, c.FClassCategory
                           where c.FClassCategory == s.selectmap
                           group c by c.FClassName into g
                           select new
                           {
                               FClassName = g.Key
                           };
                return Json(list);
            }
            else
            {
                return Json(new { FClassName = "" });
            }
        }
    }
}
