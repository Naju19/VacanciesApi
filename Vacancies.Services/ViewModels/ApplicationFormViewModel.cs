namespace Vacancies.Services.ViewModels
{
    public class ApplicationFormViewModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int VacancyId { get; set; }

        public int? CVFileId { get; set; }

        public DateTime AppliedDate { get; set; } = DateTime.Now;
    }
}
