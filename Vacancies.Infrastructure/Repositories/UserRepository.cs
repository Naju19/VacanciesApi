using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacancies.Core;
using Vacancies.Domain.Entities;

namespace Vacancies.Infrastructure.Repositories
{
    public class UserRepository(VacancyDbContext context) : GenericRepository<User>(context), IUserRepository
    {
        
        
    }
}
