using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;

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


        bool Send();

        bool Send(MailMessage message);

        bool Send(string toAddress, string subject, string messageBody);

        bool Send(string toAddress, string subject, string messageBody, Attachment attachment);

    }
}
