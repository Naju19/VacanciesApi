using AutoMapper;
using System.Security.Cryptography;
using Vacancies.Domain.Entities;
using Vacancies.Infrastructure.Repositories;
using Vacancies.Services.Responses;
using Vacancies.Services.ViewModels;

namespace Vacancies.Services.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswersRepository _answersRepository;
        private readonly IUserRepository _userRepository;
        private readonly IVacancyRepository _vacancyRepository;
        private readonly IOptionRepository _optionRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IQuestionService _questionService;
        private readonly IMapper _mapper;
        public AnswerService(IAnswersRepository answersRepository, IUserRepository userRepository, IVacancyRepository vacancyRepository, IOptionRepository optionRepository, IQuestionRepository questionRepository, IQuestionService questionService, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _optionRepository = optionRepository;
            _vacancyRepository = vacancyRepository;
            _userRepository = userRepository;
            _answersRepository = answersRepository;
            _questionService = questionService;
            _mapper = mapper;
        }
        public async Task<ResponseResult<AnswerViewModel>> CreateAsync(AnswerViewModel answerViewModel)
        {
            var response = new ResponseResult<AnswerViewModel>();
            try
            {
                var entity = _mapper.Map<Answer>(answerViewModel);
                entity.User = await _userRepository.GetByIdAsync(entity.UserId);
                entity.Vacancy = await _vacancyRepository.GetByIdAsync(entity.VacancyId);
                entity.Option = await _optionRepository.GetByIdAsync(entity.OptionId);

                var result = await _answersRepository.CreateAsync(entity);

                response.Result = _mapper.Map<AnswerViewModel>(result);
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public async Task<ResponseResult<ApplicantResultViewModel>> GetTestResult(int vacancyId, int userId)
        {
            var response = new ResponseResult<ApplicantResultViewModel>();

            try
            {
                var vacancy = await _vacancyRepository.GetByIdAsync(vacancyId);

                var answers = await _answersRepository.GetAsync(a => a.VacancyId == vacancyId && a.UserId == userId, new List<string>() { "Option" });

                var questions = await _questionService.QuestionsByVacancyIdAsync(userId, vacancyId);
                var questionsOptions = questions.Result;

                //var options = await _optionRepository.GetAsync(o => ), new List<string>() { "Question" });

                //var anweredQuestions = from a in answers
                //                       join selectedop in options on a.OptionId equals selectedop.Id
                //                       from corrOpt in options.Where(x=>x.IsCorrect==true)
                //                       select new
                //                       {

                //                           QuesionCount = vacancy.QuestionCount,
                //                           QuestionText = selectedop.Question.QuestionText,
                //                           CorrectOption = corrOpt.OptionText,
                //                           AnsweredOption=selectedop.OptionText,


                //           };



                var answeredQuestions = (from a in answers
                                         join ques in questionsOptions on a.Option.QuestionId equals ques.Id

                                         //where ques.Options.Contains(a.Option)
                                         select new AnswerDetailViewModel
                                         {
                                             QuestionText = ques.QuestionText,
                                             IsCorrect = a.Option.IsCorrect,
                                             //CorrectOption = op.Options.Where(o => o.IsCorrect && o.QuestionId == ques.Id).FirstOrDefault().OptionText,
                                             AnsweredOption = a.Option.OptionText,
                                             Seconds = a.Seconds
                                         }).ToList();

                response.Result = new ApplicantResultViewModel
                {
                    QuesionCount = vacancy.QuestionCount,
                    Answers = answeredQuestions
                };
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }
            return response;
        }
    }
}
