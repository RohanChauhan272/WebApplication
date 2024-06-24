using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, IMainRepo main, IEmailService emailService, ApplicationDbContext context)
        {
            _logger = logger;
            _main = main;
            _emailService = emailService;
            _context = context;
        }

        public IActionResult Index()
        {
            try
            {
                var GetAllData = _main.GetMainData();
                return View(GetAllData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult About()
        {
            try
            {
                var GetAllAboutData = _main.GetAboutMainData();
                return View(GetAllAboutData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            var GetContactData = _main.GetContactData();
            return View(GetContactData);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> sendMail(ContactDet contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ContactViewModel contactView = contact.contactView;
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

        public IActionResult Services()
        {
            try
            {
                var GetAllServiceData = _main.GetServiceMainData();
                return View(GetAllServiceData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
