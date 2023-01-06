using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ApiDemo.Users
{
    public interface IUserService : IApplicationService
    {
        // Task<UserDto> GetAsync(Guid id);

        // Task<PagedResultDto<UserDto>> GetListAsync(GetUserListDto input);

        Task<UserDto> CreateAsync(CreateUserDto input);

        Task <UserDto> VerifyAsync(VerifyUserDto input);

        Task UpdateAsync(Guid id, UpdateUserDto input);

        Task<UserDto> AddPackageAsync(CreateUserReadingPackageDto input);
        Task<UserDto> AddHistoryAsync(CreateUserHistoryDto input);

        // Task DeleteAsync(Guid id);
    }
}
