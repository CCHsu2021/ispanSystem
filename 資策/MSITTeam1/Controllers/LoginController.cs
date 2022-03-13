using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSITTeam1.Models;
using MSITTeam1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace MSITTeam1.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult login()
        {
            ViewBag.ERROR = "";
            ViewBag.Account = Request.Form["txtAccount"];
            ViewBag.Password = Request.Form["txtPassword"];
            string account = ViewBag.Account;
            string password = ViewBag.Password;
            helloContext db = new helloContext();
            byte[] passwordbyte = Encoding.UTF8.GetBytes(password);
            byte[] saltbyte = new byte[20];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltbyte);
            }
            SHA384Managed sha = new SHA384Managed();
            byte[] merged = passwordbyte.Concat(saltbyte).ToArray();
            byte[] passwordhashed = sha.ComputeHash(merged);
            TMember mem = db.TMembers.FirstOrDefault(p => p.FAccount == account);
            if (mem != null)
            {
                byte[] passwordhash = mem.FPassword.ToArray();
                byte[] salt = mem.FSalt.ToArray();
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                SHA384Managed shaM = new SHA384Managed();
                byte[] hashBytes = shaM.ComputeHash(passwordBytes.Concat(salt).ToArray());
                if (passwordhash.SequenceEqual(hashBytes))
                {
                    string act = mem.FAccount;
                    string type = mem.FMemberType.ToString();
                    HttpContext.Session.SetString(CDictionary.SK_LOGINED_USER_ACCOUNT, act);
                    HttpContext.Session.SetString(CDictionary.SK_LOGINED_USER_ACCOUNT, type);
                    return RedirectPermanent("../Index");
                }
            }
            ViewBag.ERROR = "帳號密碼錯誤請重新輸入";
            return RedirectToAction("Index");
        }

        public string register(String account,String password)
        {
            helloContext db = new helloContext();
            TMember mem = db.TMembers.FirstOrDefault(p => p.FAccount == account);
            if(mem != null)
            {
                return "此帳號已被註冊過";
            }
            byte[] passwordbyte = Encoding.UTF8.GetBytes(password);
            byte[] saltbyte = new byte[20];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltbyte);
            }
            SHA384Managed sha = new SHA384Managed();
            byte[] merged = passwordbyte.Concat(saltbyte).ToArray();
            byte[] passwordhashed = sha.ComputeHash(merged);
            TMember viewModel = new TMember()
            {
                FAccount = account,
                FPassword = passwordhashed,
                FSalt = saltbyte,
                FMemberType = 1,
            };
            db.TMembers.Add(viewModel);
            db.SaveChanges();
            return "帳號註冊成功";
        }
        public string getUserName()
        {
            string account = "";
            string type = "";
            string Username = "";
            if (HttpContext.Session.Keys.Contains(CDictionary.SK_LOGINED_USER_ACCOUNT))
            {
                account = HttpContext.Session.GetString(CDictionary.SK_LOGINED_USER_ACCOUNT);
                type = HttpContext.Session.GetString(CDictionary.SK_LOGINED_USER_MEMBERTYPE);
                helloContext hello = new helloContext();
                if (type == "1")
                {
                    StudentBasic stu = hello.StudentBasics.FirstOrDefault(p => p.FAccount == account);
                    Username = stu.Name;
                }
                else if (type == "2")
                {
                    TCompanyBasic com = hello.TCompanyBasics.FirstOrDefault(p => p.FAccount == account);
                    Username = com.FName;
                }
            }
            return Username;
        }
    }
}
