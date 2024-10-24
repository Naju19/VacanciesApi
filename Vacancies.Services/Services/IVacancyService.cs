using Vacancies.Domain.Entities;
using Vacancies.Services.Responses;
using Vacancies.Services.ViewModels;

namespace Vacancies.Services.Services
{
    public interface IVacancyService
    {
        Task<ResponseResult<List<VacancyViewModel>>> GetVacancyListAsync();

        Task<ResponseResult<VacancyViewModel>> GetVacancyByIdAsync(int id);
    }
}
