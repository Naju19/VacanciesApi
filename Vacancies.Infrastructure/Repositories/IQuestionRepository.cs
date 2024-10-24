using Vacancies.Domain.Entities;

namespace Vacancies.Infrastructure.Repositories
{
    public interface IQuestionRepository : IGenericRepository<Question>
    {
        Task<List<Question>> GetQuestionListAsync();
    }
}
