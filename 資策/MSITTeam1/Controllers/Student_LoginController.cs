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
using System.Web;

namespace MSITTeam1.Controllers
{
    public class Student_LoginController : Controller
    {
        private readonly helloContext hello;
        //private readonly SHA384Managed sha;

        public Student_LoginController(helloContext _hello)
        {
            hello = _hello;
        //    sha = _sha;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult verifyAccount (String verify)
        {
            if (verify == "")
            {
                ViewData["ErrorMsg"] = "缺少驗證碼";
                return RedirectToAction("Index");
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
                return RedirectToAction("Index");
            }
            string UserID = verify.Split('|')[0];
            StudentBasic stu = hello.StudentBasics.FirstOrDefault(p => p.FAccount == UserID);
            if(stu != null && stu.FCheckStatus == "no")
            {
                stu.FCheckStatus = "yes";
                ViewData["SucMsg"] = "驗證成功";
                return RedirectToAction("Index");
            }           
                return RedirectToAction("Index");
        }
        public string login(String account, String password)
        {
            if (password != null)
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
                StudentBasic mem = hello.StudentBasics.FirstOrDefault(p => p.FAccount == account);
                if(mem.FCheckStatus == "no")
                {
                    return "請先至信箱認證信件";
                }
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
            //Todo 測試完刪除下面程式碼
            else if(password == "" || password == null)
            {
                StudentBasic mem = hello.StudentBasics.FirstOrDefault(p => p.FAccount == account);
                if (mem != null)
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

        public IActionResult resendEmail(string account)
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
            string Action = "Student_Login/verifyAccount";
            string path = "<a href='" + webPath + Action + "?verify=" + sVerify + "'>點此連結認證信箱</a>";

            return Content("發送成功");
        }
        public string register(String account,String password)
        {
            SHA384Managed sha = new SHA384Managed();
            StudentBasic mem = hello.StudentBasics.FirstOrDefault(p => p.FAccount == account);
            if(mem != null)
            {
                return "此帳號已被註冊過";
            }
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
            string Action = "Student_Login/verifyAccount"; 
            string path = "<a href='" + webPath + Action + "?verify=" + sVerify + "'>點此連結認證信箱</a>";

            byte[] passwordbyte = Encoding.UTF8.GetBytes(password);
            byte[] saltbyte = new byte[20];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltbyte);
            }
            byte[] merged = passwordbyte.Concat(saltbyte).ToArray();
            byte[] passwordhashed = sha.ComputeHash(merged);
            StudentBasic viewModel = new StudentBasic()
            {
                FAccount = account,
                FPassword = passwordhashed,
                FSalt = saltbyte,
                FMemberType = 1,
                FCheckStatus = "no",
                FGuid = sVerify,
            };
            hello.StudentBasics.Add(viewModel);
            hello.SaveChanges();
            return "帳號註冊成功";
        }
        public string getUserName()
        {
            string account = "";
            if (HttpContext.Session.Keys.Contains(CDictionary.SK_LOGINED_USER_ACCOUNT))
            {
                account = HttpContext.Session.GetString(CDictionary.SK_LOGINED_USER_ACCOUNT);
                StudentBasic stu = hello.StudentBasics.FirstOrDefault(p => p.FAccount == account);
                CDictionary.account = stu.MemberId;
                if (stu.Name.Trim() == "未填寫")
                {
                    CDictionary.username = "親愛的學員";
                    CDictionary.memtype = stu.FMemberType.ToString();
                }
                else
                {
                    CDictionary.username = stu.Name;
                    CDictionary.memtype = stu.FMemberType.ToString();
                }
            }
            return CDictionary.username;
        }
        public string ValidAccount(string account)
        {
            string tpyein = account;
            string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            bool flag = Regex.IsMatch(tpyein, pattern);
            if (flag)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }
        public IActionResult PWDidentify()
        {
            return View();
        }
        public IActionResult MailPWDresetLink(string account)
        {
            StudentBasic com = hello.StudentBasics.FirstOrDefault(p => p.FAccount == account);
            if (com != null)
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
                string Action = "Student_Login/ForgetPWD";
                string path = "<a href='" + webPath + Action + "?verify=" + sVerify + "'>點此連結</a>";
                CMailDelivery.mail(account, com.Name, path);
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
            StudentBasic com = hello.StudentBasics.FirstOrDefault(p => p.FAccount == account);
            if (com != null)
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
                com.FAccount = account;
                com.FPassword = passwordhashed;
                com.FSalt = saltbyte;
                hello.SaveChanges();
            }
            return Content("修改成功");
        }

    }
}
