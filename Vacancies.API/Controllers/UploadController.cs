using Microsoft.AspNetCore.Mvc;
using Vacancies.Domain.Entities;
using Vacancies.Services.ViewModels;

namespace Vacancies.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : Controller
    {

        private readonly IWebHostEnvironment _hostingEnvironment;
        public UploadController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Post(FileViewModel fileViewModel)
        {
            string uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");

            if (fileViewModel.FileContent.Length > 0)
            {
                string filePath = Path.Combine(uploads, fileViewModel.FileContent.FileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await fileViewModel.FileContent.CopyToAsync(fileStream);
                }
            }
            return null;
        }
    }
}
