using sourceBackup.Portal.Data;
using System.ComponentModel;

namespace sourceBackup.Portal.Models
{
    public class SupportRequest : GoogleReCaptchaModelBase
    {
        [DisplayName("Your email")]
        public string Email { get; set; }

        [DisplayName("CC yourself a copy")]
        public bool CarbonCopyUser { get; set; }

        [DisplayName("email body (put your request details here)")]
        public string RequestBody { get; set; }
        public bool SendSuccess { get; set; } = false;
    }
}
