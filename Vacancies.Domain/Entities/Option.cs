using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vacancies.Domain.Entities
{
    public class Option : IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string OptionText { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public bool IsCorrect {  get; set; }
    }
}
