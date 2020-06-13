using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sourceBackup.Portal.Areas.Download.Interfaces;
using sourceBackup.Portal.Areas.Mail.Interfaces;
using sourceBackup.Portal.Data.Interfaces;
using sourceBackup.Portal.Models;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Mail;
using System.Threading.Tasks;

namespace sourceBackup.Portal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAppSettings _appSettings;
        private readonly IServiceProvider _serviceProvider;
        private readonly ISetupFile _setupFile;

        public HomeController(ILogger<HomeController> logger, IAppSettings appSettings, IServiceProvider serviceProvider, ISetupFile setupFile)
        {
            _logger = logger;
            _appSettings = appSettings;
            _serviceProvider = serviceProvider;
            _setupFile = setupFile;
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
                if (ModelState.IsValid)
                {
                    var mailMessage = (IGmailMessage)_serviceProvider.GetService(typeof(IGmailMessage));

                    var toAddress = new MailAddress(_appSettings.GetAppSetting("adminEmail"));

                    var addres = new MailAddress(supportRequest.Email);
                    mailMessage.Subject = "Project Source Backup Tool Portal Support Request";
                    mailMessage.From = addres;
                    if (supportRequest.CarbonCopyUser)
                    {
                        mailMessage.CC.Add(addres);
                    }
                    mailMessage.To.Add(toAddress);
                    mailMessage.Body = supportRequest.RequestBody;
                    supportRequest.SendSuccess = await mailMessage.SendAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Home.Suuport()");
            }
            return View(supportRequest);

        }


        [HttpGet]
        public IActionResult Download()
        {
            // send the setup file
            return _setupFile.DownloadAsync();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
