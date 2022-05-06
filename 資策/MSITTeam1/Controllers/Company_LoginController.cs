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
using System.Web;

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
            if(password != null) { 
            SHA384Managed sha = new SHA384Managed();
            byte[] passwordbyte = Encoding.UTF8.GetBytes(password);
            byte[] saltbyte = new byte[20];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltbyte);
            }
            byte[] merged = passwordbyte.Concat(saltbyte).ToArray();
            byte[] passwordhashed = sha.ComputeHash(merged);
            TCompanyBasic mem = hello.TCompanyBasics.FirstOrDefault(p => p.CompanyTaxid == account);
            if (mem != null)
            {
                byte[] passwordhash = mem.FPassword.ToArray();
                byte[] salt = mem.FSalt.ToArray();
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha.ComputeHash(passwordBytes.Concat(salt).ToArray());
                if (passwordhash.SequenceEqual(hashBytes))
                {
                    string act = mem.CompanyTaxid;
                    HttpContext.Session.SetString(CDictionary.SK_LOGINED_USER_ACCOUNT, act);
                    string name = getUserName();
                    return $"{name}";
                }
            }
                return "帳號密碼錯誤請重新輸入";
            }else if (password == null)
            {
                TCompanyBasic mem = hello.TCompanyBasics.FirstOrDefault(p => p.CompanyTaxid == account);
                if (mem != null)
                { 
                    string act = mem.CompanyTaxid;
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
            TCompanyBasic mem = hello.TCompanyBasics.FirstOrDefault(p => p.CompanyTaxid == account);
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
            TCompanyBasic company = new TCompanyBasic()
            {
                CompanyTaxid = account,
                FPassword = passwordhashed,
                FSalt = saltbyte,
                FLevel = 1
            };
            hello.TCompanyBasics.Add(company);
            hello.SaveChanges();
            return "帳號註冊成功";
        }
        public string getUserName()
        {
            string account = "";
            if (HttpContext.Session.Keys.Contains(CDictionary.SK_LOGINED_USER_ACCOUNT))
            {
                account = HttpContext.Session.GetString(CDictionary.SK_LOGINED_USER_ACCOUNT);
                TCompanyBasic com = hello.TCompanyBasics.FirstOrDefault(p => p.CompanyTaxid == account);
                CDictionary.memtype = "2";
                CDictionary.account = account;
                if (com.FName == null)
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
       
        
        public IActionResult PWDidentify()
        {
            return View();
        }
        public IActionResult MailPWDresetLink(string account,string email)
        {
            TCompanyBasic com = hello.TCompanyBasics.FirstOrDefault(p => p.CompanyTaxid == account & p.FEmail == email);
            if(com != null)
            {
                string sVerify = account + "|" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] buf = Encoding.UTF8.GetBytes("IspanMsit40");
                byte[] result = md5.ComputeHash(buf);
                string md5Key = BitConverter.ToString(result).Replace("-", "").ToLower().Substring(0, 24);
                DES.Key = UTF8Encoding.UTF8.GetBytes(md5Key);
                DES.Mode = CipherMode.ECB;
                ICryptoTransform DESEncrypt = DES.CreateEncryptor();
                byte[] Buffer = UTF8Encoding.UTF8.GetBytes(sVerify);
                sVerify = Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));

                sVerify = HttpUtility.UrlEncode(sVerify);
                string webPath = Request.Scheme + "://" + Request.Host + Url.Content("~/");
                string Action = "Company_Login/ForgetPWD";
                string path = "<a href='" + webPath + Action + "?verify=" + sVerify + "'>點此連結</a>";
                CMailDelivery.mail(email, account,path);
                return Content("已發送郵件至信箱");
            }
            return Json(new { fail = "找不到用戶" });
        }
        public IActionResult ForgetPWD(string verify)
        {

            if (verify == "")
            {
                ViewData["ErrorMsg"] = "缺少驗證碼";
                return View();
            }
            string SecretKey = "IspanMsit40";
            try
            {
                TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] buf = Encoding.UTF8.GetBytes(SecretKey);
                byte[] md5result = md5.ComputeHash(buf);
                string md5Key = BitConverter.ToString(md5result).Replace("-", "").ToLower().Substring(0, 24);
                DES.Key = UTF8Encoding.UTF8.GetBytes(md5Key);
                DES.Mode = CipherMode.ECB;
                DES.Padding = PaddingMode.PKCS7;
                ICryptoTransform DESDecrypt = DES.CreateDecryptor();
                byte[] Buffer = Convert.FromBase64String(verify);
                string deCode = UTF8Encoding.UTF8.GetString(DESDecrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));

                verify = deCode;
            }
            catch (Exception ex)
            {
                ViewData["ErrorMsg"] = "驗證碼錯誤";
                return View();
            }
            string UserID = verify.Split('|')[0];
            string ResetTime = verify.Split('|')[1];
            DateTime dResetTime = Convert.ToDateTime(ResetTime);
            TimeSpan TS = new System.TimeSpan(DateTime.Now.Ticks - dResetTime.Ticks);
            double diff = Convert.ToDouble(TS.TotalMinutes);
            if (diff > 30)
            {
                ViewData["ErrorMsg"] = "超過驗證碼有效時間，請重寄驗證碼";
                return View();
            }
            HttpContext.Session.SetString("ResetPwdUserId", UserID);
            return View();
        }

        public IActionResult ResetPWD(String password)
        {
            string account = HttpContext.Session.GetString("ResetPwdUserId");
            TCompanyBasic com = hello.TCompanyBasics.FirstOrDefault(p => p.CompanyTaxid == account);
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
                com.CompanyTaxid = account;
                com.FPassword = passwordhashed;
                com.FSalt = saltbyte;
                hello.SaveChanges();
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
