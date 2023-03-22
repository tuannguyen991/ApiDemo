using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ApiDemo.Users
{
    public interface IUserService : IApplicationService
    {
        Task<UserDto> CreateAsync(CreateUserDto input);

        Task <Guid> VerifyAsync(VerifyUserDto input);

        Task <UserDto> GetAsync(Guid id);

        Task UpdateAsync(Guid id, UpdateUserDto input);

        Task<UserDto> AddPackageAsync(CreateUserReadingPackageDto input);
        Task<UserReadingPackageDto> GetUserReadingPackageAsync(Guid userId);

        Task<UserDto> AddHistoryAsync(CreateUserHistoryDto input);

        Task<List<HighlightDto>> AddHighlightAsync(CreateHighlightDto input);

        Task<List<HighlightDto>> GetHighlightsAsync(GetHighlightDto input);

        Task DeleteHighlightAsync(DeleteHighlightDto input);

        Task<List<UserLibraryDto>> GetReadingBooksAsync(Guid id);

        Task<List<UserLibraryDto>> GetFavoriteBooksAsync(Guid id);

        Task AddReadingBookAsync(CreateUserLibraryDto input);
        
        Task AddFavoriteBookAsync(CreateUserLibraryDto input);
    }
}
