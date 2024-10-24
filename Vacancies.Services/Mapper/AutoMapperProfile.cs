using AutoMapper;
using Vacancies.Domain.Entities;
using Vacancies.Services.ViewModels;

namespace Vacancies.Services.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<UserViewModel, User>().ReverseMap();
            CreateMap<VacancyViewModel, Vacancy>().ReverseMap();
            CreateMap<QuestionViewModel, Question>().ReverseMap();
            CreateMap<AnswerViewModel, Answer>().ReverseMap();
            CreateMap<ApplicationFormViewModel, ApplicationForm>().ReverseMap();
        }
    }
}
