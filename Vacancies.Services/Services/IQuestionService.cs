using Vacancies.Services.Responses;
using Vacancies.Services.ViewModels;

namespace Vacancies.Services.Services
{
    public interface IQuestionService
    {
        Task<ResponseResult<TestsViewModel>> RandomQuestionsByVacancyIdAsync(int userId, int vacancyId);

        Task<ResponseResult<List<QuestionViewModel>>> QuestionsByVacancyIdAsync(int userId, int vacancyId);
    }
}
