using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vacancies.Domain.Entities
{
    //this this represent every answer to result, by question,second,and is answered
    public class Answer : IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? OptionId { get; set; }
        public Option? Option { get; set; }

        public int VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }

        public int UserId {  get; set; }
        public User User { get; set; }

        public int Seconds { get; set; }
    }
}
