using System.ComponentModel.DataAnnotations;
using Vacancies.Domain.Entities;
using Vacancies.Domain.Enums;

namespace Vacancies.Services.ViewModels
{
    public class VacancyViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Header { get; set; }

        public string Description { get; set; }

        public Categories CategoryId { get; set; }

        public VacancyStatus Status { get; set; }

        public int QuestionCount { get; set; }

        public DateTime PublishDate { get; set; }

        public List<Tags> Tags { get; set; }

        public IList<User> Users { get; set; } =new List<User>();
    }
}
