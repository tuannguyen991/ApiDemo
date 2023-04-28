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

        Task <UserDto> GetAsync(string id);

        Task UpdateAsync(string id, UpdateUserDto input);

        Task<UserDto> AddPackageAsync(CreateUserReadingPackageDto input);

        Task<UserDto> AddHistoryAsync(CreateUserHistoryDto input);

        Task<List<HighlightDto>> AddHighlightAsync(CreateHighlightDto input);

        Task UpdateHighlightAsync(Guid highLightId, UpdateHighlightDto input);

        Task<List<HighlightDto>> GetHighlightsAsync(string userId, string bookId);

        Task<HighlightNotificationDto> GetHighlightNotificationAsync(string userId);

        Task DeleteHighlightAsync(DeleteHighlightDto input);

        Task<List<UserLibraryDto>> GetReadingBooksAsync(string id);

        Task<List<UserLibraryDto>> GetFavoriteBooksAsync(string id);

        Task<bool> GetIsFavoriteAsync(string id, string bookId);

        Task AddReadingBookAsync(CreateUserLibraryDto input);
        
        Task AddFavoriteBookAsync(CreateUserLibraryDto input);

        Task DeleteFavoriteBookAsync(string userId, string bookId);

        Task UploadImageAsync(string id, string path);
    }
}
