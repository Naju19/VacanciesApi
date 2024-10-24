using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vacancies.Domain.Enums;

namespace Vacancies.Domain.Entities
{
    public class Question : IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Categories CategoryId { get; set; }

        public string QuestionText { get; set; }

        public virtual List<Tags> Tags { get; set; }

        public virtual IList<Option> Options { get; set; }

    }
}
