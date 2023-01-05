using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ApiDemo.Users
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        Task<User> FindByUsernameAsync(string username);

        // Task<List<User>> GetListAsync(
        //     int skipCount,
        //     int maxResultCount,
        //     string sorting,
        //     string filter = null
        // );
    }
}
