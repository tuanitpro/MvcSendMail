/* FileName: SendMailController.cs
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

using System.Web.Mvc;
using MvcSendMail.Models;

namespace MvcSendMail.Controllers
{
    public class SendMailController : AsyncController
    {
        //
        // GET: /SendMail/

        public ActionResult Index()
        {
            var model = new ContactModel();
            return View(model);
        }

        [HttpPost]
        [AsyncTimeout(200)]
        public ActionResult Index(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                // Gửi mail

                string smtpUserName = "tuanitpro@gmail.com";
                string smtpPassword = "zgoerigfjndorwiv";
                string smtpHost = "smtp.gmail.com";
                int smtpPort = 25;

                string emailTo = "tuanitpro@gmail.com"; // Khi có liên hệ sẽ gửi về thư của mình
                string subject = model.Subject;
                string body = string.Format("Bạn vừa nhận được liên hệ từ: <b>{0}</b><br/>Email: {1}<br/>Nội dung: </br>{2}",
                    model.UserName, model.Email, model.Message);

                EmailService service = new EmailService();

                bool kq = service.Send(smtpUserName, smtpPassword, smtpHost, smtpPort,
                    emailTo, subject, body);

                if (kq) ModelState.AddModelError("", "Cảm ơn bạn đã liên hệ với chúng tôi.");
                else ModelState.AddModelError("", "Gửi tin nhắn thất bại, vui lòng thử lại.");
            }
            return View(model);
        }
    }
}