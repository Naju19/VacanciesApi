using Vacancies.Core;
using Vacancies.Domain.Entities;

namespace Vacancies.Infrastructure.Repositories
{
    public class OptionRepository(VacancyDbContext context) : GenericRepository<Option>(context), IOptionRepository
    {
    }
}
