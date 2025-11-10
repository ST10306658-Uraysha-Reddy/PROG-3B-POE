using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using municipalService.Models;
using municipalService.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace municipalService.Controllers
{
    public class ReportFormModelsController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public ReportFormModelsController(IWebHostEnvironment env)
        {
            _env = env;
        }

        // GET: /ReportFormModels/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /ReportFormModels/Submit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit(ReportFormModel model)
        {
            if (ModelState.IsValid)
            {
                // Generate unique reference
                string reference = $"REP-{DateTime.Now:yyyyMMdd}-{Guid.NewGuid().ToString().Substring(0, 6).ToUpper()}";
                model.Reference = reference;

                // Handle file upload
                if (model.FileUpload != null && model.FileUpload.Length > 0)
                {
                    var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
                    Directory.CreateDirectory(uploadsFolder);

                    var fileName = Path.GetFileName(model.FileUpload.FileName);
                    var filePath = Path.Combine(uploadsFolder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.FileUpload.CopyToAsync(stream);
                    }

                    model.FilePath = "/uploads/" + fileName;
                }

                // Save to static list
                ReportStorage.Reports.Add(model);

                // Show confirmation view
                return View("Confirmation", model);
            }

            // If invalid model state
            return View("Create", model);
        }

        // GET: /ReportFormModels/Table
        [HttpGet]
        public IActionResult Table()
        {
            return View(ReportStorage.Reports);
        }
        // GET: /ReportFormModels/Table
        [HttpGet]
        public IActionResult Confrimation()
        {
            return View();
        }
    }
}