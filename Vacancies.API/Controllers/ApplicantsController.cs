using Microsoft.AspNetCore.Mvc;
using Vacancies.Services.Services;
using Vacancies.Services.ViewModels;

namespace Vacancies.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantsController : ControllerBase
    {
        private readonly IApplicantService _applicantService;
        public ApplicantsController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }

        // GET: api/Applicants/5
        [HttpGet("{vacancyId}")]
        public async Task<IActionResult> GetApplicants(int vacancyId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _applicantService.GetApplicantsByVacancyId(vacancyId);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return NotFound();

            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                return Problem(response.ErrorMessage);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostResult(ApplicationFormViewModel applicationFormViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _applicantService.CreateAppFormAsync(applicationFormViewModel);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return NotFound();

            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                return Problem(response.ErrorMessage);

            return Ok(response);
        }

    }
}
