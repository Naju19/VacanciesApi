using Vacancies.Domain.Entities;

namespace Vacancies.Services.ViewModels
{
    public class ApplicantViewModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }

        public int? CVFileId { get; set; }
        public CVFile? CVFile { get; set; }

        public DateTime AppliedDate { get; set; }

        public List<Answer> Answers { get; set; }
    }
}
