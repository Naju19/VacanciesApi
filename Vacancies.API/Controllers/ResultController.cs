using Microsoft.AspNetCore.Mvc;
using Vacancies.Services.Services;
using Vacancies.Services.ViewModels;

namespace Vacancies.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly IAnswerService _answerService;

        public ResultController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [HttpGet("{userId}/{vacancyId}")]
        public async Task<IActionResult> GetUserResultByVacancyIdForm(int userId,int vacancyId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _answerService.GetTestResult(vacancyId,userId);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return NotFound();

            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                return Problem(response.ErrorMessage);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostApplicationForm(AnswerViewModel answerViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _answerService.CreateAsync(answerViewModel);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return NotFound();

            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                return Problem(response.ErrorMessage);

            return Ok(response);
        }

    }
}
