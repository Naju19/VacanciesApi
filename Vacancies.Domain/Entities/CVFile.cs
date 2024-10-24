using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vacancies.Domain.Entities
{
    public class CVFile : IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        //public File File { get; set; }

        public DateTime DateTime { get; set; }

        
    }
}
