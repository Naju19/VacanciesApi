using Vacancies.Core;
using Vacancies.Domain.Entities;

namespace Vacancies.Infrastructure.Repositories
{
    public class AnswerRepository(VacancyDbContext context) : GenericRepository<Answer>(context), IAnswersRepository
    {

    }
}
