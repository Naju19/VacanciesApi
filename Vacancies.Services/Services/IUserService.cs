using Vacancies.Services.Responses;
using Vacancies.Services.ViewModels;

namespace Vacancies.Services.Services
{
    public interface IUserService
    {
        Task<ResponseResult<UserViewModel>> CreateAsync(UserViewModel userViewModel);
    }
}
