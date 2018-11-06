using System.Threading.Tasks;

namespace SendMailCore.Services
{
    public interface IEmailService
    {
        Task<bool> Send(string smtpUserName, string smtpPassword, string smtpHost, int smtpPort,
             string toEmail, string subject, string body);
    }
}