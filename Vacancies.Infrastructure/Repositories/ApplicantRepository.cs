using Vacancies.Core;
using Vacancies.Domain.Entities;

namespace Vacancies.Infrastructure.Repositories
{
    public class ApplicantRepository(VacancyDbContext context) : GenericRepository<ApplicationForm>(context) , IApplicantRepository
    {
    }
}
