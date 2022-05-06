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
                message.From.Add(new MailboxAddress(System.Text.Encoding.UTF8, "資展國際股份有限公司", "資展國際股份有限公司"));
                message.To.Add(new MailboxAddress(System.Text.Encoding.UTF8, account, emailaddress));
                message.Subject = "《資展國際股份有限公司》忘記密碼重設信";
                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = $"<div>****此信件為系統發出信件，請勿直接回覆，感謝您的配合。謝謝****</div>";
                bodyBuilder.HtmlBody = $"<div>親愛的  {account}  您好：</div><hr>";
                bodyBuilder.HtmlBody += $"<div>您於{DateTime.Now.ToString("yyyy-MM-dd tt HH:mm:ss")}申請忘記密碼</div><br>";
                bodyBuilder.HtmlBody += $"<div>如您未申請此功能請忽略此郵件</div><br>";
                bodyBuilder.HtmlBody += $"請點擊以下連結，返回網站重新設定密碼，逾期 30 分鐘後，此連結將會失效。<br>";
                bodyBuilder.HtmlBody += $"----------------------------------------------------------------------------------------------------------------<br>";
                bodyBuilder.HtmlBody += $"{webpath}<br>";
                bodyBuilder.HtmlBody += $"----------------------------------------------------------------------------------------------------------------<br>";
                bodyBuilder.HtmlBody += $"<br>";
                bodyBuilder.HtmlBody += $"<br>";
                bodyBuilder.HtmlBody += $"<br>";
                bodyBuilder.HtmlBody += $"<br>";
                bodyBuilder.HtmlBody += $"<div>如有任何問題請隨時與我們聯繫</div><br>";
                bodyBuilder.HtmlBody += $"<div>Tel : (02) 6631-6588(台北窗口)</div><br>";
                bodyBuilder.HtmlBody += $"<div>地址 : 台北市復興南路一段390號2樓</div><br>";
                bodyBuilder.HtmlBody += $"<div>(大安捷運站4號、6號出口)</div><br>";
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
