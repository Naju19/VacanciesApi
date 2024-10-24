using Vacancies.Services.Responses;
using Vacancies.Services.ViewModels;

namespace Vacancies.Services.Services
{
    public interface IAnswerService
    {
        Task<ResponseResult<AnswerViewModel>> CreateAsync(AnswerViewModel answerViewModel);

        Task<ResponseResult<ApplicantResultViewModel>> GetTestResult(int vacancyId, int userId);
    }
}
