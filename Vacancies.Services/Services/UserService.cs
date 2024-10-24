using AutoMapper;
using Vacancies.Domain.Entities;
using Vacancies.Infrastructure.Repositories;
using Vacancies.Services.Responses;
using Vacancies.Services.ViewModels;

namespace Vacancies.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;

        }
        public async Task<ResponseResult<UserViewModel>> CreateAsync(UserViewModel userViewModel)
        {
            var response = new ResponseResult<UserViewModel>();
            try
            {
                var entity = _mapper.Map<User>(userViewModel);

                var result = await _userRepository.CreateAsync(entity);

                response.Result = _mapper.Map<UserViewModel>(result);

            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }
            return response;
        }
    }
}
