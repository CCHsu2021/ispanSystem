using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSITTeam1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.SetString(CDictionary.SK_LOGINED_USER_ACCOUNT, "");
            HttpContext.Session.SetString(CDictionary.SK_LOGINED_USER_MEMBERTYPE, "");
            CDictionary.username = "";
            CDictionary.memtype = "";
            return Redirect("../Index");
        }
    }
}
