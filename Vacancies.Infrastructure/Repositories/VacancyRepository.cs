using Vacancies.Core;
using Vacancies.Domain.Entities;

namespace Vacancies.Infrastructure.Repositories
{
    public class VacancyRepository(VacancyDbContext context) : GenericRepository<Vacancy>(context), IVacancyRepository
    {
        public async Task<List<Vacancy>> GetVacancyListAsync()
        {
           return await base.GetAsync();
        }

        public async Task<Vacancy> GetVacancyByIdAsync(int id)
        {
            return await base.GetByIdAsync(id);
        }
    }
}
