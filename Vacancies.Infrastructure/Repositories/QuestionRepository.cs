using Vacancies.Core;
using Vacancies.Domain.Entities;

namespace Vacancies.Infrastructure.Repositories
{
    public class QuestionRepository(VacancyDbContext context) : GenericRepository<Question>(context), IQuestionRepository
    {
        public async Task<List<Question>> GetQuestionListAsync()
        {
            return await base.GetAsync(null, new List<string>() { "Options" });
        }
    }
}
