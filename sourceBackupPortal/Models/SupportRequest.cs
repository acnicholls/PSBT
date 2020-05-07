namespace sourceBackup.Portal.Models
{
    public class SupportRequest
    {
        public string Email { get; set; }
        public bool ccEmail { get; set; }
        public string RequestBody { get; set; }
        public bool SendSuccess { get; set; } = false;
    }
}
