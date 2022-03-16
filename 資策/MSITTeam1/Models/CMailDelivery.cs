using MailKit.Net.Smtp;
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
        public static string mail(string emailaddress,string account,string password)
        {
            try
            {
                MimeMessage message = new MimeMessage();
                message.From.Add(new MailboxAddress(System.Text.Encoding.UTF8, "Ispan.International.Company@gmail.com", "資展國際股份有限公司"));
                message.To.Add(new MailboxAddress(System.Text.Encoding.UTF8, account, emailaddress));
                message.Subject = "《資展國際股份有限公司》帳號/密碼通知信";
                var bodyBuilder = new BodyBuilder();
                bodyBuilder.TextBody = $"親愛的{account}您好\n";
                bodyBuilder.TextBody += $"您於{DateTime.Now.ToString("yyyyMMdd")}申請忘記密碼\n";
                bodyBuilder.TextBody += $"如您未申請此功能請忽略此郵件\n";
                bodyBuilder.TextBody += $"以下是您的密碼\n";
                bodyBuilder.TextBody += $"------------------------------------------------------\n";
                bodyBuilder.TextBody += $"密碼：{password}";
                bodyBuilder.TextBody += $"------------------------------------------------------\n";
                bodyBuilder.TextBody += $"\n";
                bodyBuilder.TextBody += $"\n";
                bodyBuilder.TextBody += $"\n";
                bodyBuilder.TextBody += $"\n";
                bodyBuilder.TextBody += $"如有任何問題請隨時與我們聯繫";
                message.Body = bodyBuilder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    var hostUrl = "smtp.gmail.com";
                    var port = 587;
                    var useSsl = true;


                    client.Connect(hostUrl, port, useSsl);


                    // client.Authenticate("account", "password");

                    client.Send(message);

                    client.Disconnect(true);
                }
                message.Dispose();
                return "success"; 
            }
            catch
            {
                return "false";
            }
         






        }
    }
}
