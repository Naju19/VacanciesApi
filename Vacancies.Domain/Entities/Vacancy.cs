using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vacancies.Domain.Enums;

namespace Vacancies.Domain.Entities
{
    public class Vacancy : IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        public virtual IList<User> Users { get; set; }
    }
}
