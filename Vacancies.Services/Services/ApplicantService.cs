using AutoMapper;
using Vacancies.Domain.Entities;
using Vacancies.Infrastructure.Repositories;
using Vacancies.Services.Responses;
using Vacancies.Services.ViewModels;

namespace Vacancies.Services.Services
{
    public class ApplicantService : IApplicantService
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IAnswersRepository _answersRepository;
        private readonly IUserRepository _userRepository;
        private readonly IVacancyRepository _vacancyRepository;
        private readonly IMapper _mapper;
        public ApplicantService(IApplicantRepository applicantRepository, IVacancyRepository vacancyRepository, IUserRepository userRepository, IAnswersRepository answersRepository, IMapper mapper)
        {
            _answersRepository = answersRepository;
            _userRepository = userRepository;
            _applicantRepository = applicantRepository;
            _vacancyRepository = vacancyRepository;
            _mapper = mapper;
        }

        public async Task<ResponseResult<ApplicationForm>> CreateAppFormAsync(ApplicationFormViewModel applicationFormViewModel)
        {
            var responseResult = new ResponseResult<ApplicationForm>();
            try
            {
                var entity = _mapper.Map<ApplicationForm>(applicationFormViewModel);
                entity.User = await _userRepository.GetByIdAsync(entity.UserId);
                entity.Vacancy = await _vacancyRepository.GetByIdAsync(entity.VacancyId);

                var result = await _applicantRepository.CreateAsync(entity);

                responseResult.Result = result;
            }
            catch (Exception ex)
            {
                responseResult.ErrorMessage = ex.Message;
            }
            return responseResult;
        }

        public async Task<ResponseResult<List<ApplicantViewModel>>> GetApplicantsByVacancyId(int vacancyId)
        {
            var response = new ResponseResult<List<ApplicantViewModel>>();
            try
            {
                var applicants = await _applicantRepository.GetAsync(x => x.VacancyId == vacancyId, new List<string> { "User", "Vacancy" });

                var answers = await _answersRepository.GetAsync(x => x.VacancyId == vacancyId);


                response.Result = (from applicant in applicants
                                   select new ApplicantViewModel
                                   {
                                       Id = applicant.Id,
                                       UserId = applicant.UserId,
                                       User = applicant.User,
                                       VacancyId = applicant.VacancyId,
                                       Vacancy = applicant.Vacancy,
                                       AppliedDate = applicant.AppliedDate,
                                       Answers = answers.Where(x => x.UserId == applicant.UserId).ToList()
                                   }).ToList();
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }
            return response;
        }
    }
}
