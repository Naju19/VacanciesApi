using Microsoft.AspNetCore.Mvc;
using Vacancies.Services.Services;

namespace Vacancies.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public TestsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        // GET: api/Questions/vacancyId/userId
        [HttpGet("{userId}/{vacancyId}")]
        public async Task<IActionResult> GetTests(int userId,int vacancyId )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _questionService.RandomQuestionsByVacancyIdAsync(vacancyId, userId);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return NotFound();

            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                return Problem(response.ErrorMessage);

            return Ok(response);
        }

    }
}
