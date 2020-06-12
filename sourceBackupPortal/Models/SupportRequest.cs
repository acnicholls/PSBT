﻿using sourceBackup.Portal.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace sourceBackup.Portal.Models
{
    public class SupportRequest : GoogleReCaptchaModelBase
    {
        [Required]
        [DisplayName("your email")]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("CC yourself a copy")]
        public bool CarbonCopyUser { get; set; }

        [Required]
        [DisplayName("email body")]
        public string RequestBody { get; set; }
        public bool SendSuccess { get; set; } = false;
    }
}
