using Microsoft.AspNetCore.Mvc;
using sourceBackup.Portal.Data.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace sourceBackup.Portal.Data
{
    public class GoogleReCaptchaModelBase
    {
        [Required]
        [GoogleReCaptchaValidation]
        [BindProperty(Name ="g-recaptcha-response")]
        [DisplayName("Google reCAPTCHA Response")]
        public string GoogleReCaptchaResponse { get; set; }
    }
}
