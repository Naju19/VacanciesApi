using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vacancies.Domain.Entities
{
    public class ApplicationForm : IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int VacancyId {  get; set; }
        public Vacancy Vacancy { get; set; }

        public int? CVFileId {  get; set; }
        public CVFile? CVFile { get; set; }

        public DateTime AppliedDate { get; set; }
    }
}
