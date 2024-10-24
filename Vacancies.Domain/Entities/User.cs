using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vacancies.Domain.Enums;

namespace Vacancies.Domain.Entities
{
    public class User : IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Surname { get; set; }

        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public required string Email { get; set; }

        [StringLength(50)]
        [DataType(DataType.PhoneNumber)] //format
        public required string PhoneNumber { get; set; }

        public Roles Roles { get; set; }

        public virtual List<Vacancy>? Vacancies { get; set; }
    }
}
