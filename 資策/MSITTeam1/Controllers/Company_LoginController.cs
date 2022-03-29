using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSITTeam1.Models;
using MSITTeam1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MSITTeam1.Controllers
{

    public class Company_LoginController : Controller
    {
        private readonly helloContext hello;

        public Company_LoginController(helloContext _hello)
        {
            hello = _hello;
        }
        public IActionResult Index()
        {
            return View();
        }
        public string login(String account, String password)
        {
            SHA384Managed sha = new SHA384Managed();
            //helloContext hello = new helloContext();
            byte[] passwordbyte = Encoding.UTF8.GetBytes(password);
            byte[] saltbyte = new byte[20];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltbyte);
            }
            byte[] merged = passwordbyte.Concat(saltbyte).ToArray();
            byte[] passwordhashed = sha.ComputeHash(merged);
            TCompanyBasic mem = hello.TCompanyBasics.FirstOrDefault(p => p.FAccount == account);
            if (mem != null)
            {
                byte[] passwordhash = mem.FPassword.ToArray();
                byte[] salt = mem.FSalt.ToArray();
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha.ComputeHash(passwordBytes.Concat(salt).ToArray());
                if (passwordhash.SequenceEqual(hashBytes))
                {
                    string act = mem.FAccount;
                    HttpContext.Session.SetString(CDictionary.SK_LOGINED_USER_ACCOUNT, act);
                    string name = getUserName();
                    return $"{name}";
                }
            }
            return "帳號密碼錯誤請重新輸入";
        }

        public string register(String account, String password)
        {
            SHA384Managed sha = new SHA384Managed();
            TCompanyBasic mem = hello.TCompanyBasics.FirstOrDefault(p => p.FAccount == account);
            if (mem != null)
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
                FMemberType = 2,
            };
            hello.TMembers.Add(viewModel);
            hello.SaveChanges();
            return "帳號註冊成功";
        }
        public string getUserName()
        {
            string account = "";
            if (HttpContext.Session.Keys.Contains(CDictionary.SK_LOGINED_USER_ACCOUNT))
            {
                account = HttpContext.Session.GetString(CDictionary.SK_LOGINED_USER_ACCOUNT);
                TCompanyBasic com = hello.TCompanyBasics.FirstOrDefault(p => p.FAccount == account);
                if (com.FName == "")
                {
                    CDictionary.username = "親愛的用戶";
                }
                else
                {
                    CDictionary.username = com.FName;
                }
            }
            return CDictionary.username;
        } 
       
        

        public IActionResult ForgetPWD()
        {
            return View();
        }

        public IActionResult ResetPWD(String password)
        {
            string account = "company1";
            TCompanyBasic com = hello.TCompanyBasics.FirstOrDefault(p => p.FAccount == account);
            if(com != null)
            {
                SHA384Managed sha = new SHA384Managed();
                byte[] passwordbyte = Encoding.UTF8.GetBytes(password);
                byte[] saltbyte = new byte[20];
                using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
                {
                    rng.GetBytes(saltbyte);
                }
                byte[] merged = passwordbyte.Concat(saltbyte).ToArray();
                byte[] passwordhashed = sha.ComputeHash(merged);
            }
            return Content("修改成功");
        }

        public string PasswordIdentify(CForgetPasswordAccountViewModel fpav)
        {
            //helloContext hello = new helloContext();
            TMember member = hello.TMembers.FirstOrDefault(p => p.FAccount == fpav.account);
            if (member != null)
            {

                if (member.FMemberType == 1)
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
