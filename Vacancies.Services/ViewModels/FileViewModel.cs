using Microsoft.AspNetCore.Http;

namespace Vacancies.Services.ViewModels
{
    public class FileViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IFormFile FileContent { get; set; }

        public int UserId {  get; set; }

        public int VacancyId {  get; set; }
    }
}
