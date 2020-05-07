using Microsoft.Extensions.Logging;
using sourceBackup.Portal.Areas.Mail.Interfaces;
using sourceBackup.Portal.Data.Interfaces;
using System;
using System.Net.Mail;

namespace sourceBackup.Portal.Areas.Mail
{

    /// <summary>
    /// Provides a message object that sends the email through gmail. 
    /// GmailMessage is inherited from <c>System.Net.Mail.MailMessage</c>, so all the mail message features are available.
    /// </summary>
    public class GmailMessage : System.Net.Mail.MailMessage, IGmailMessage
    {
        private readonly IAppSettings _appSettings;
        private readonly ILogger<GmailMessage> _logger;

        #region Private Variables

        private string _gmailServer => _appSettings.GetAppSetting("smtpServer", false);
        private long _gmailPort => Convert.ToInt64(_appSettings.GetAppSetting("smtpPort", false));
        private string _gmailUserName => _appSettings.GetAppSetting("smtpUser", false);
        private string _gmailPassword => _appSettings.GetAppSetting("smtpPassword", false);

        AttachmentCollection IGmailMessage.Attachments { get => base.Attachments; }
        MailAddressCollection IGmailMessage.CC { get => base.CC; }
        MailAddressCollection IGmailMessage.To { get => base.To; }
        //MailAddress IGmailMessage.From 
        #endregion

        #region Public Members

        /// <summary>
        /// Constructor, creates the GmailMessage object
        /// </summary>
        public GmailMessage(IAppSettings appSettings, ILogger<GmailMessage> logger)
        {
            _appSettings = appSettings;
            _logger = logger;
        }

        /// <summary>
        /// Sends the message. If no from address is given the message will be from <c>GmailUserName</c>@Gmail.com
        /// </summary>
        public bool Send()
        {
            bool returnValue = false;
            try
            {
                if (this.From.ToString() == string.Empty)
                {
                    this.From = new MailAddress(_gmailUserName);
                }

                System.Net.Mail.SmtpClient newClient = new SmtpClient(_gmailServer, (int)_gmailPort);
                newClient.EnableSsl = true;
                newClient.Credentials = new System.Net.NetworkCredential(_gmailUserName, _gmailPassword);
                newClient.SendMailAsync(this);
                returnValue = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GmailMessage.Send");
            }
            return returnValue;
        }

        #endregion

        #region Static Members

        /// <summary>
        /// Send a <c>System.Web.Mail.MailMessage</c> through the specified gmail account
        /// </summary>
        /// <param name="message"><c>System.Web.Mail.MailMessage</c> object to send</param>
        public bool Send(MailMessage message)
        {
            bool returnValue = false;
            try
            {

                System.Net.Mail.SmtpClient newClient = new SmtpClient(_gmailServer, (int)_gmailPort);
                newClient.EnableSsl = true;
                newClient.Credentials = new System.Net.NetworkCredential(_gmailUserName, _gmailPassword);
                newClient.Send(message);
                returnValue = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GmailMessage.SendMailMessageFromGmail");
            }
            return returnValue;
        }

        /// <summary>
        /// Sends an email through the specified gmail account
        /// </summary>
        /// <param name="toAddress">Recipients email address</param>
        /// <param name="subject">Message subject</param>
        /// <param name="messageBody">Message body</param>
        public bool Send(string toAddress, string subject, string messageBody)
        {
            bool returnValue = false;
            try
            {
                MailMessage gMessage = new MailMessage();

                gMessage.To.Add(new MailAddress(toAddress));
                gMessage.Subject = subject;
                gMessage.Body = messageBody;
                gMessage.From = new MailAddress(_gmailUserName);

                System.Net.Mail.SmtpClient newClient = new SmtpClient(_gmailServer, (int)_gmailPort);
                newClient.EnableSsl = true;
                newClient.Credentials = new System.Net.NetworkCredential(_gmailUserName, _gmailPassword);
                newClient.SendMailAsync(gMessage);
                returnValue = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GmailMessage.SendFromGmail");
            }
            return returnValue;
        }
        public bool Send(string toAddress, string subject, string messageBody, Attachment attachment)
        {
            bool returnValue = false;
            try
            {
                MailMessage gMessage = new MailMessage();

                gMessage.To.Add(new MailAddress(toAddress));
                gMessage.Subject = subject;
                gMessage.Body = messageBody;
                gMessage.From = new MailAddress(_gmailUserName);

                gMessage.Attachments.Add(attachment);

                System.Net.Mail.SmtpClient newClient = new SmtpClient(_gmailServer, (int)_gmailPort);
                newClient.EnableSsl = true;
                newClient.Credentials = new System.Net.NetworkCredential(_gmailUserName, _gmailPassword);
                newClient.Send(gMessage);
                returnValue = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GmailMessage.SendFromGmail /w attachment");
            }
            return returnValue;
        }
        #endregion

    } //GmailMessage

} //acnicholls.common
