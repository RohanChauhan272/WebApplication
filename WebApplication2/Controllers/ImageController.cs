using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using WebAppPort.Data.IRepository;
using WebAppPort.Entities.MainModel;

namespace WebApplication2.Controllers
{
    public class ImageController : Controller
    {
        private readonly ILogger<ImageController> _logger;
        private readonly IMainRepo _main;
        private readonly IEmailService _emailService;
        private readonly ApplicationDbContext _context;

        public ImageController(ILogger<ImageController> logger, IMainRepo main, IEmailService emailService, ApplicationDbContext context)
        {
            _logger = logger;
            _main = main;
            _emailService = emailService;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Image/Upload
        public IActionResult Upload()
        {
            return View();
        }

        // POST: /Image/Upload
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                ViewBag.Message = "Please select an image file.";
                return View();
            }

            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    byte[] imageData = memoryStream.ToArray();

                    // Save image to database
                    Image image = new Image
                    {
                        ImageName = file.FileName,
                        ImageData = imageData
                    };

                    _main.SaveImageToDatabase(image.ImageName, image.ImageData);

                    //_context.Images.Add(image);
                    //await _context.SaveChangesAsync();

                    ViewBag.Message = "Image uploaded successfully!";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Error uploading image: {ex.Message}";
            }

            return View();
        }

        [BindProperty]
        public IFormFile ImageFile { get; set; }

        public string UploadStatusMessage { get; set; }
    }
}
