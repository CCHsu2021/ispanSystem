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
                    return RedirectPermanent("https://localhost:44387/");
                }
            }
            ViewBag.ERROR = "帳號密碼錯誤請重新輸入";
            return RedirectToAction("Index");
        }
        public IActionResult register()
        {
            ViewBag.ERROR = "";
            ViewBag.Account = Request.Form["txtAccount"];
            ViewBag.Password = Request.Form["txtPassword"];
            string account = ViewBag.Account;
            string password = ViewBag.Password;
            helloContext db = new helloContext();
            TMember mem = db.TMembers.FirstOrDefault(p => p.FAccount == account);
            if(mem != null)
            {
                ViewBag.ERROR = "此帳號已註冊過";
                return RedirectToAction("Index");
            }
            if (IsTheSame())
            {
                ViewBag.ERROR = "輸入密碼不同請重新輸入";
                return RedirectToAction("Index");
            }
            if (IsValid())
            {
                ViewBag.ERROR = "密碼格式輸入錯誤";
                return RedirectToAction("Index");
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
            CTMemberViewModel viewModel = new CTMemberViewModel()
            {
                FAccount = account,
                FPassword = passwordhashed,
                FSalt = saltbyte,
                FMemberType = 1,
            };
            db.TMembers.Add(viewModel.member);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        private bool IsTheSame()
        {
            ViewBag.P1 = Request.Form["txtPassword"];
            ViewBag.P2 = Request.Form["txtPassword2"];
            if(ViewBag.P1 == ViewBag.P2)
                return false;
            return true;
        }
        private bool IsValid()
        {
            ViewBag.P1 = Request.Form["txtPassword"];
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$";
            if (Regex.IsMatch(ViewBag.P1, pattern))
                return false;
            return true;
        }
    }
}
