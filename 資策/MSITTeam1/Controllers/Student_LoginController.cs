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
        public string login(String account, String password)
        {
            if (password != "")
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

        public string register(String account,String password)
        {
            SHA384Managed sha = new SHA384Managed();
            StudentBasic mem = hello.StudentBasics.FirstOrDefault(p => p.FAccount == account);
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
            StudentBasic viewModel = new StudentBasic()
            {
                FAccount = account,
                FPassword = passwordhashed,
                FSalt = saltbyte,
                FMemberType = 1,
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
            //bool flag = Regex.IsMatch(tpyein, @"^[A-Za-z]{1}[1-2]{1}[0-9]{8}$");
            //int[] ID = new int[11];
            //int count = 0;
            //string result = "false";
            //tpyein = tpyein.ToUpper();
            //if (flag == true)
            //{
            //    switch (tpyein.Substring(0, 1))
            //    {
            //        case "A": (ID[0], ID[1]) = (1, 0); break;
            //        case "B": (ID[0], ID[1]) = (1, 1); break;
            //        case "C": (ID[0], ID[1]) = (1, 2); break;
            //        case "D": (ID[0], ID[1]) = (1, 3); break;
            //        case "E": (ID[0], ID[1]) = (1, 4); break;
            //        case "F": (ID[0], ID[1]) = (1, 5); break;
            //        case "G": (ID[0], ID[1]) = (1, 6); break;
            //        case "H": (ID[0], ID[1]) = (1, 7); break;
            //        case "I": (ID[0], ID[1]) = (3, 4); break;
            //        case "J": (ID[0], ID[1]) = (1, 8); break;
            //        case "K": (ID[0], ID[1]) = (1, 9); break;
            //        case "L": (ID[0], ID[1]) = (2, 0); break;
            //        case "M": (ID[0], ID[1]) = (2, 1); break;
            //        case "N": (ID[0], ID[1]) = (2, 2); break;
            //        case "O": (ID[0], ID[1]) = (3, 5); break;
            //        case "P": (ID[0], ID[1]) = (2, 3); break;
            //        case "Q": (ID[0], ID[1]) = (2, 4); break;
            //        case "R": (ID[0], ID[1]) = (2, 5); break;
            //        case "S": (ID[0], ID[1]) = (2, 6); break;
            //        case "T": (ID[0], ID[1]) = (2, 7); break;
            //        case "U": (ID[0], ID[1]) = (2, 8); break;
            //        case "V": (ID[0], ID[1]) = (2, 9); break;
            //        case "W": (ID[0], ID[1]) = (3, 2); break;
            //        case "X": (ID[0], ID[1]) = (3, 0); break;
            //        case "Y": (ID[0], ID[1]) = (3, 1); break;
            //        case "Z": (ID[0], ID[1]) = (3, 3); break;
            //    }
            //    for (int i = 2; i < ID.Length; i++)
            //    {
            //        ID[i] = Convert.ToInt32(tpyein.Substring(i - 1, 1));
            //    }
            //    for (int j = 1; j < ID.Length - 1; j++)
            //    {
            //        count += ID[j] * (10 - j);
            //    }
            //    count += ID[0] + ID[10];
            //    if (count % 10 == 0)
            //    {
            //        result = "true";
            //    }
            //    else
            //    {
            //        result = "false";
            //    }
            //}
            //else
            //{
            //    result = "false";
            //}     
            //return result;
        }
        public IActionResult ForgetPWD()
        {
            return View();
        }
        public IActionResult ResetPWD(String password)
        {
            string account = "111";
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
        public string PasswordIdentify(CForgetPasswordAccountViewModel fpav)
        {
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
