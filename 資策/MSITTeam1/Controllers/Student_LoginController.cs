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
    public class Student_LoginController : Controller
    {
        //private readonly helloContext hello;
        //private readonly SHA384Managed sha;

        //public LoginController(helloContext _hello, SHA384Managed _sha)
        //{
        //    hello = _hello;
        //    sha = _sha;
        //}
        public IActionResult Index()
        {
            return View();
        }
        public string login(String account, String password)
        {
            SHA384Managed sha = new SHA384Managed();
            helloContext hello = new helloContext();
            byte[] passwordbyte = Encoding.UTF8.GetBytes(password);
            byte[] saltbyte = new byte[20];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltbyte);
            }
            byte[] merged = passwordbyte.Concat(saltbyte).ToArray();
            byte[] passwordhashed = sha.ComputeHash(merged);
            TMember mem = hello.TMembers.FirstOrDefault(p => p.FAccount == account);
            if (mem != null)
            {
                byte[] passwordhash = mem.FPassword.ToArray();
                byte[] salt = mem.FSalt.ToArray();
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha.ComputeHash(passwordBytes.Concat(salt).ToArray());
                if (passwordhash.SequenceEqual(hashBytes))
                {
                    string act = mem.FAccount;
                    string type = mem.FMemberType.ToString();
                    HttpContext.Session.SetString(CDictionary.SK_LOGINED_USER_ACCOUNT, act);
                    HttpContext.Session.SetString(CDictionary.SK_LOGINED_USER_MEMBERTYPE, type);
                    string name = getUserName();
                    return $"{name}";
                }
            }
            return "帳號密碼錯誤請重新輸入";
        }

        public string register(String account,String password)
        {
            SHA384Managed sha = new SHA384Managed();
            helloContext hello = new helloContext();
            TMember mem = hello.TMembers.FirstOrDefault(p => p.FAccount == account);
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
            byte[] merged = passwordbyte.Concat(saltbyte).ToArray();
            byte[] passwordhashed = sha.ComputeHash(merged);
            TMember viewModel = new TMember()
            {
                FAccount = account,
                FPassword = passwordhashed,
                FSalt = saltbyte,
                FMemberType = 1,
            };
            hello.TMembers.Add(viewModel);
            hello.SaveChanges();
            return "帳號註冊成功";
        }
        public string getUserName()
        {
            helloContext hello = new helloContext();
            string account = "";
            string type = "";
            string Username = "";
            if (HttpContext.Session.Keys.Contains(CDictionary.SK_LOGINED_USER_ACCOUNT))
            {
                account = HttpContext.Session.GetString(CDictionary.SK_LOGINED_USER_ACCOUNT);
                type = HttpContext.Session.GetString(CDictionary.SK_LOGINED_USER_MEMBERTYPE);
                if (type == "1")
                {
                    StudentBasic stu = hello.StudentBasics.FirstOrDefault(p => p.FAccount == account);
                    if (stu == null)
                    {
                        CDictionary.username = "親愛的用戶";
                    }
                    else
                    {
                        CDictionary.username = stu.Name;
                    }
                }
                else if (type == "2")
                {
                    TCompanyBasic com = hello.TCompanyBasics.FirstOrDefault(p => p.FAccount == account);
                    if (com == null)
                    {
                        CDictionary.username = "親愛的用戶";
                    }
                    else
                    {
                        CDictionary.username = com.FName;
                    }
                }
            }
            return Username;
        }

        public IActionResult ForgetPWD()
        {
            return View();
        }

        public string PasswordIdentify(CForgetPasswordAccountViewModel fpav)
        {
            helloContext hello = new helloContext();
            TMember member = hello.TMembers.FirstOrDefault(p => p.FAccount == fpav.account);
            if(member != null)
            {

                if(member.FMemberType == 1)
                {
                    StudentBasic stu = hello.StudentBasics.FirstOrDefault(p => p.Email == fpav.email);
                }
                else if (member.FMemberType == 2)
                {
                    TCompanyBasic cmp = hello.TCompanyBasics.FirstOrDefault(p => p.FEmail == fpav.email);
                }
            }
            return "查無此帳號或是Email輸入錯誤";
        }
        public string AccountIdentify()
        {
            return "1";
        }
    }
}
