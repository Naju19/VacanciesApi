using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacancies.Domain.Entities;

namespace Vacancies.Services.ViewModels
{
    public class ResultsViewModel
    {
        public ResultsViewModel()
        {
            Score=Answers.Where(x=>x.OptionId !=null &&  x.Option.IsCorrect).ToList().Count;
            
            // Helper calculate Persentage Vacancy.Total and Score
        }
        public int UserId { get; set; }

        public int VacancyId { get; set; }

        public int Score { get; set; }

        public float Persentage { get; set; }

        public List<Answer> Answers { get; set; }
    }
}
