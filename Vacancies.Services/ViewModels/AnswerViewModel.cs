using Vacancies.Domain.Entities;

namespace Vacancies.Services.ViewModels
{
    public class AnswerViewModel
    {
        public int Id { get; set; }

        public int OptionId { get; set; }

        public int VacancyId { get; set; }

        public int UserId { get; set; }

        public int Seconds { get; set; }

        public bool IsCorrect { get; set; } = false;
    }
}
