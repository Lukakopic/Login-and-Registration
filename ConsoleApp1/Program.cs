using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            SendVerificationLinkEmail();

        }

        private static void SendVerificationLinkEmail()
        {
            //var verifyUrl = "/User/VerifyAccount/" + activationCode;
            //var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress("gm.xsmilex@gmail.com");
            var toEmail = new MailAddress("marjanovic.goran@gmail.com");
            var fromEmailPassword = "1408Macak!"; //Replace with actual password
            string subject = "Your account is succesfully created!";

            string body = "<br/><br/>We are excited to tell you that your Dotnet Awesome account is" +
                " Successfully created. Please click on the below link to verify your account" +
                " <br/><br/><a href= 'aa'></a>";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object s,
                        System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                        System.Security.Cryptography.X509Certificates.X509Chain chain,
                        System.Net.Security.SslPolicyErrors sslPolicyErrors)
            {
                return true;
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);
        }
    }
}
