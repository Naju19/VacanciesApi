using AutoMapper;
using Vacancies.Domain.Entities;
using Vacancies.Infrastructure.Repositories;
using Vacancies.Services.Responses;
using Vacancies.Services.ViewModels;

namespace Vacancies.Services.Services
{
    public class VacancyService : IVacancyService
    {
        public readonly IVacancyRepository _vacancyRepository;
        private readonly IMapper _mapper;


        public VacancyService(IVacancyRepository vacancyRepository, IMapper mapper)
        {
            _vacancyRepository = vacancyRepository;
            _mapper = mapper;
        }
        public async Task<ResponseResult<List<VacancyViewModel>>> GetVacancyListAsync()
        {
            var response = new ResponseResult<List<VacancyViewModel>>();
            try
            {
                var entity = await _vacancyRepository.GetVacancyListAsync();

                response.Result = (_mapper.Map<List<VacancyViewModel>>(entity));
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public async Task<ResponseResult<VacancyViewModel>> GetVacancyByIdAsync(int id)
        {
            var response = new ResponseResult<VacancyViewModel>();
            try
            {
                var entity = await _vacancyRepository.GetVacancyByIdAsync(id);

                response.Result = (_mapper.Map<VacancyViewModel>(entity));
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }
            return response;
        }
    }
}
