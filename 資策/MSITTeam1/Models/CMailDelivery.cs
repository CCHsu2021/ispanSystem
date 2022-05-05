using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.IdentityModel.Protocols;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MSITTeam1.Models
{
    public class CMailDelivery
    {
        public static string mail(string emailaddress,string account,string webpath)
        {
                MimeMessage message = new MimeMessage();
                message.From.Add(new MailboxAddress(System.Text.Encoding.UTF8, "Ispan.International.Company@gmail.com", "資展國際股份有限公司"));
                message.To.Add(new MailboxAddress(System.Text.Encoding.UTF8, account, emailaddress));
                message.Subject = "《資展國際股份有限公司》忘記密碼重設信";
                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = $"<div>親愛的  {account}  您好</div><hr><br><br>";
                bodyBuilder.HtmlBody += $"<div>您於{DateTime.Now.ToString("yyyyMMdd g")}申請忘記密碼</div><br><br>";
                bodyBuilder.HtmlBody += $"<div>如您未申請此功能請忽略此郵件</div><br><br>";
                bodyBuilder.HtmlBody += $"請點擊以下連結，返回網站重新設定密碼，逾期 30 分鐘後，此連結將會失效。<br><br>";
                bodyBuilder.HtmlBody += $"------------------------------------------------------------------------<br>";
                bodyBuilder.HtmlBody += webpath;
                bodyBuilder.HtmlBody += $"------------------------------------------------------------------------<br>";
                bodyBuilder.HtmlBody += $"<br>";
                bodyBuilder.HtmlBody += $"<br>";
                bodyBuilder.HtmlBody += $"<br>";
                bodyBuilder.HtmlBody += $"<br>";
                bodyBuilder.HtmlBody += $"<div>如有任何問題請隨時與我們聯繫</div>";
                message.Body = bodyBuilder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    var hostUrl = "smtp.gmail.com";
                    var port = 587;
                    //var useSsl = true;


                    client.Connect(hostUrl, port, false);


                    client.Authenticate("Ispan.International.Company@gmail.com", "Aa19950617");

                    client.Send(message);

                    client.Disconnect(true);
                }
                message.Dispose();
                return "success"; 
            }
        }
    }
