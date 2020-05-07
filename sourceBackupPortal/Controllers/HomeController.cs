using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sourceBackup.Portal.Areas.Mail.Interfaces;
using sourceBackup.Portal.Data.Interfaces;
using sourceBackup.Portal.Models;
using System;
using System.Diagnostics;
using System.Net.Mail;
using System.Threading.Tasks;

namespace sourceBackup.Portal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAppSettings _appSettings;
        private readonly IServiceProvider _serviceProvider;

        public HomeController(ILogger<HomeController> logger, IAppSettings appSettings, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _appSettings = appSettings;
            _serviceProvider = serviceProvider;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Tutorial()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Support()
        {
            var requestModel = new SupportRequest();
            return View(requestModel);
        }

        [HttpPost]
        public async Task<IActionResult> Support(SupportRequest supportRequest)
        {
            try
            {
                var mailMessage = (IGmailMessage)_serviceProvider.GetService(typeof(IGmailMessage));

                var toAddress = new MailAddress(_appSettings.GetAppSetting("adminEmail"));

                var addres = new MailAddress(supportRequest.Email);
                mailMessage.Subject = "Project Source Backup Tool";
                mailMessage.From = addres;
                if (supportRequest.ccEmail)
                {
                    mailMessage.CC.Add(addres);
                }
                mailMessage.To.Add(toAddress);
                mailMessage.Body = supportRequest.RequestBody;
               supportRequest.SendSuccess = await mailMessage.SendAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Home.Suuport()");
            }
            return View(supportRequest);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
