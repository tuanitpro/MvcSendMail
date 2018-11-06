﻿/* FileName: EmailService.cs
Project Name: MvcSendMail
Date Created: 9/15/2014PM
Description: Auto-generated
Version: 1.0.0.0
Author:	Lê Thanh Tuấn - Khoa CNTT
Author Email: tuanitpro@gmail.com
Author Mobile: 0976060432
Author URI: http://tuanitpro.com
License:

*/

using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace MvcSendMail.Models
{
    /// <summary>
    /// Email Service
    /// Class gửi mail
    /// </summary>
    public class EmailService
    {
        /// <summary>
        /// Hàm thực thi gửi mail trong MVC
        /// </summary>
        /// <param name="smtpUserName">Ten dang nhap cua smtp server: vd: tuanitpro@gmail.com</param>
        /// <param name="smtpPassword">Mat khau dang nhap</param>
        /// <param name="smtpHost">SMTP của host: vd: smtp.gmail.com</param>
        /// <param name="smtpPort">Port vd: 25 - gmail</param>
        /// <param name="toEmail">Email của người nhận</param>
        /// <param name="subject">Chủ đề email</param>
        /// <param name="body">Nội dung thư gửi</param>
        /// <returns>True - Thành công / False - Thất bại</returns>
        public bool Send(string smtpUserName, string smtpPassword, string smtpHost, int smtpPort,
            string toEmail, string subject, string body)
        {
            try
            {
                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.EnableSsl = true; //https,
                    smtpClient.Host = smtpHost; // host
                    smtpClient.Port = smtpPort; // port
                    smtpClient.UseDefaultCredentials = true;
                    smtpClient.Credentials = new NetworkCredential(smtpUserName, smtpPassword);
                    var msg = new MailMessage
                    {
                        IsBodyHtml = true, // Cho phép nội dung HTML
                        BodyEncoding = Encoding.UTF8, // UTF-8
                        From = new MailAddress(smtpUserName),
                        Subject = subject,
                        Body = body,
                        Priority = MailPriority.Normal,
                    };

                    msg.To.Add(toEmail);
                    Object state = msg;
                    smtpClient.SendCompleted += smtpClient_SendCompleted;
                    smtpClient.SendAsync(msg, state);

                    return mailSent;
                }
            }
            catch
            {
                return false;
            }
        }

        private bool mailSent = false;

        private void smtpClient_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            MailMessage token = e.UserState as MailMessage;
            if (e.Cancelled)
            {
                mailSent = false;
                Console.WriteLine("[{0}] Send canceled.", token);
            }
            if (e.Error != null)
            {
                mailSent = false;
                Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
            }
            else
            {
                mailSent = true;
                Console.WriteLine("Message sent.");
            }
            mailSent = true;
        }
    }
}