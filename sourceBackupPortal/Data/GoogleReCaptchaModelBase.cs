using Microsoft.AspNetCore.Mvc;
using sourceBackup.Portal.Data.Validation;
using System.ComponentModel.DataAnnotations;

namespace sourceBackup.Portal.Data
{
    public class GoogleReCaptchaModelBase
    {
        [Required]
        [GoogleReCaptchaValidation]
        [BindProperty(Name ="g-recaptcha-response")]
        public string GoogleReCaptchResponse { get; set; }
    }
}
