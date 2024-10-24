using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Vacancies.Domain.Entities;
using Vacancies.Infrastructure.Repositories;
using Vacancies.Services.Responses;
using Vacancies.Services.ViewModels;

namespace Vacancies.Services.Services
{
    public class QuestionService : IQuestionService
    {
        public readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;
        private readonly IVacancyService _vacancyService;

        public QuestionService(IQuestionRepository questionRepository, IMapper mapper, IVacancyService vacancyService)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
            _vacancyService = vacancyService;
        }
        public async Task<ResponseResult<TestsViewModel>> RandomQuestionsByVacancyIdAsync(int userId, int vacancyId)
        {
            var response = new ResponseResult<TestsViewModel>();
            try
            {
                Random rnd = new Random();

                var vacancy = await _vacancyService.GetVacancyByIdAsync(vacancyId);

                if (vacancy == null || vacancy?.Result == null)
                    throw new Exception($"Vacancy coudn't by Vacancy id: {vacancyId}.Details: {vacancy?.ErrorMessage}");

                var questions = await _questionRepository.GetQuestionListAsync();

                var vacancyQuestions = await QuestionsByVacancyIdAsync(userId, vacancyId);

                if (vacancyQuestions.Result != null)
                {
                    var randomQuestions = vacancyQuestions.Result
                                    .OrderBy(r => rnd.Next())
                                    .Take(vacancy.Result.QuestionCount).ToList();

                    response.Result = new TestsViewModel
                    {
                        UserId = userId,
                        VacancyId = vacancyId,
                        Questions = randomQuestions
                    };
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public async Task<ResponseResult<List<QuestionViewModel>>> QuestionsByVacancyIdAsync(int userId, int vacancyId)
        {
            var response = new ResponseResult<List<QuestionViewModel>>();
            try
            {
                Random rnd = new Random();

                var vacancy = await _vacancyService.GetVacancyByIdAsync(vacancyId);

                if (vacancy == null || vacancy?.Result == null)
                    throw new Exception($"Vacancy coudn't by Vacancy id: {vacancyId}.Details: {vacancy?.ErrorMessage}");

                var questions = await _questionRepository.GetQuestionListAsync();

                var result = questions
                                    .Where(q => vacancy.Result.Tags.Any(vt => q.Tags.Contains(vt)) && (int)q.CategoryId == (int)vacancy.Result.CategoryId).ToList();

                response.Result = _mapper.Map<List<QuestionViewModel>>(result);
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }
            return response;
        }
    }
}
