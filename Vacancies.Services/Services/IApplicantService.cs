using Vacancies.Domain.Entities;
using Vacancies.Services.Responses;
using Vacancies.Services.ViewModels;

namespace Vacancies.Services.Services
{
    public interface IApplicantService
    {
        Task<ResponseResult<ApplicationForm>> CreateAppFormAsync(ApplicationFormViewModel applicationFormViewModel);

        Task<ResponseResult<List<ApplicantViewModel>>> GetApplicantsByVacancyId(int vacancyId);
    }
}
