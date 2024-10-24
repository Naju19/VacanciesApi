namespace Vacancies.Services.ViewModels
{
    public class ApplicantResultViewModel
    {
        public int QuesionCount { get; set; }

        public List<AnswerDetailViewModel> Answers { get; set; }

        public int Score
        {
            get
            {
                return Answers != null ? Answers.Count() : 0;
            }
            set { }
        }

        public decimal Percentage { get 
            { 
                return (Score/QuesionCount) * 100;
            } 
            set 
            { 
            
            } 
        }

        public string Color
        {
            get
            {
                if (Percentage <= 50)
                    return "Red";
                if (Percentage > 50 && Percentage <= 75)
                    return "Yellow";
                if ((Percentage > 75))
                    return "Green";

                return string.Empty;

            }
            private set { }
        }
    }

    public class AnswerDetailViewModel
    {
        public string QuestionText { get; set; }
        public bool IsCorrect { get; set; }
        public string AnsweredOption { get; set; }
        public int Seconds { get; set; }
    }
}
