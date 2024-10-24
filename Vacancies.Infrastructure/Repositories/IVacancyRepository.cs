using Vacancies.Domain.Entities;

namespace Vacancies.Infrastructure.Repositories
{
    public interface IVacancyRepository : IGenericRepository<Vacancy>
    {
        Task<List<Vacancy>> GetVacancyListAsync();

        Task<Vacancy> GetVacancyByIdAsync(int id);
    }
}
