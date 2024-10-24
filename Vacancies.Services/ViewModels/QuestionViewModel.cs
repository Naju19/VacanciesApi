using Vacancies.Domain.Entities;
using Vacancies.Domain.Enums;

namespace Vacancies.Services.ViewModels
{
    public class QuestionViewModel
    {
        public int Id { get; set; }

        public Categories CategoryId { get; set; }

        public string QuestionText { get; set; }

        public virtual List<Tags> Tags { get; set; }

        public virtual IList<Option> Options { get; set; }
    }
}
