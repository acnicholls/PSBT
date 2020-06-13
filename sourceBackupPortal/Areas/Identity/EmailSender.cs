using Microsoft.AspNetCore.Identity.UI.Services;
using sourceBackup.Portal.Areas.Mail.Interfaces;
using System.Threading.Tasks;

namespace sourceBackup.Portal.Areas.Identity
{
    /// <summary>
    /// this class is used to send email from the portal to users across the world from the acnicholls gmail server for the user registration database
    /// - v1 - once a user is regiestered, they can access the download link
    /// </summary>
    public class EmailSender : IEmailSender
    {
        /// <summary>
        ///  the preconfigured email message
        /// </summary>
        private IGmailMessage _gmailMessage;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="gmailMessage"></param>
        public EmailSender(IGmailMessage gmailMessage)
        {
            // exchange
            _gmailMessage = gmailMessage;
        }

        /// <summary>
        /// this method sets up the required variables and sends a message through the pre-configured service
        /// </summary>
        /// <param name="email">the email address to send to</param>
        /// <param name="subject">the subject of the email</param>
        /// <param name="htmlMessage">the message</param>
        /// <returns>void</returns>
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            _gmailMessage.To.Add(email);
            _gmailMessage.Subject = subject;
            _gmailMessage.Body = htmlMessage;
            await _gmailMessage.SendAsync();
        }
    }
}
