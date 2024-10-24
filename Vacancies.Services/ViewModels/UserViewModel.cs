using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Vacancies.Domain.Enums;

namespace Vacancies.Services.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.PhoneNumber)] //format
        public string PhoneNumber { get; set; }

        public Roles Roles { get; set; }
    }
}
