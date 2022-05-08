using Microsoft.AspNetCore.Mvc;
using MSITTeam1Admin.Models;
using MSITTeam1Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1Admin.Controllers
{
    public class LoginController : Controller
    {
        private readonly helloContext hello;
        public LoginController(helloContext _hello)
        {
            hello = _hello;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(CLogin info)
        {
            TAdministrator p = hello.TAdministrators.FirstOrDefault(p => p.FAccount == info.LAccount);
            if(p != null)
            {
                if(p.FPassword == info.LPassword)
                {
                    return Redirect(Url.Content("~/Home/Index"));
                }
            }
            return RedirectToAction("Index");
        }
    }
}
