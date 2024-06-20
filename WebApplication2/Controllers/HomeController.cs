using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using WebAppPort.Data.IRepository;
using WebAppPort.Entities.MainModel;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMainRepo _main;
        private readonly IEmailService _emailService;

        public HomeController(ILogger<HomeController> logger, IMainRepo main, IEmailService emailService)
        {
            _logger = logger;
            _main = main;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            var GetAllData = _main.GetMainData();
            return View(GetAllData);
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> sendMail(ContactViewModel contactView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _emailService.SendEmailAsync(contactView.Email, contactView.Subject, $"From: {contactView.Name}\n\n{contactView.Message}");
                    return RedirectToAction("Contact");
                }
                else
                {
                    return BadRequest("Error While Sending Mail");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
