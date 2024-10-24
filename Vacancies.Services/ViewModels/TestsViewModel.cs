using Vacancies.Domain.Entities;

namespace Vacancies.Services.ViewModels
{
    public class TestsViewModel
    {
        public int VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }

        public int UserId { get; set; }

        public List<QuestionViewModel> Questions { get; set; }
    }
}
