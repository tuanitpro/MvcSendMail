using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SendMailCore.Models;
using SendMailCore.Services;

namespace SendMailCore.Controllers
{
    public class SendMailController : Controller
    {
        private readonly IEmailService _emailService;

        public SendMailController(IEmailService emailService)
        {
            this._emailService = emailService;
        }

        public async Task<IActionResult> Index() => View();

        [HttpPost]
        public async Task<IActionResult> Index(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                // Gửi mail

                string smtpUserName = "tuanitpro@gmail.com";
                string smtpPassword = "zylfkazcsaabtvkt";
                string smtpHost = "smtp.gmail.com";
                int smtpPort = 465;

                string emailTo = "tuanitpro@gmail.com"; // Khi có liên hệ sẽ gửi về thư của mình
                string subject = model.Subject;
                string body = string.Format("Bạn vừa nhận được liên hệ từ: <b>{0}</b><br/>Email: {1}<br/>Nội dung: </br>{2}",
                    model.UserName, model.Email, model.Message);

                EmailService service = new EmailService();

                bool kq = await _emailService.Send(smtpUserName, smtpPassword, smtpHost, smtpPort,
                    emailTo, subject, body);

                if (kq) ModelState.AddModelError("", "Cảm ơn bạn đã liên hệ với chúng tôi.");
                else ModelState.AddModelError("", "Gửi tin nhắn thất bại, vui lòng thử lại.");
            }
            return View(model);
        }
    }
}