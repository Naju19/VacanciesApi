using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vacancies.Domain.Entities;
using Vacancies.Services.Services;

namespace Vacancies.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacanciesController : ControllerBase
    {
        private readonly IVacancyService _vacancyService;

        public VacanciesController(IVacancyService vacancyService)
        {
            _vacancyService = vacancyService;
        }

        // GET: api/Vacancies
        [HttpGet]
        public async Task<IActionResult> GetVacancies()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _vacancyService.GetVacancyListAsync();

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return NotFound();

            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                return Problem(response.ErrorMessage);

            return Ok(response);
        }

        // GET: api/Vacancies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vacancy>> GetVacancy(int id)
        {
            //var vacancy = await _context.Vacancies.FindAsync(id);

            //if (vacancy == null)
            //{
            //    return NotFound();
            //}

            //return vacancy;
            return null;
        }
    }
}
