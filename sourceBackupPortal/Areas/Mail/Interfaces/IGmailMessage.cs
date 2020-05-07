using System.Net.Mail;
using System.Threading.Tasks;

namespace sourceBackup.Portal.Areas.Mail.Interfaces
{
    public interface IGmailMessage 
    {
        AttachmentCollection Attachments { get;  }
        string Subject { get; set; }
        MailAddress From { get; set; }
        MailAddressCollection CC { get;  }
        MailAddressCollection To { get;  }
        string Body { get; set; }


        Task<bool> SendAsync();

        Task<bool> SendAsync(MailMessage message);

        Task<bool> SendAsync(string toAddress, string subject, string messageBody);

        Task<bool> SendAsync(string toAddress, string subject, string messageBody, Attachment attachment);

    }
}
