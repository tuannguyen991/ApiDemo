using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiDemo.Users.RecommendationSystem;
using Volo.Abp.Application.Services;

namespace ApiDemo.Users
{
    public interface IUserService : IApplicationService
    {
        Task<UserDto> CreateAsync(CreateUserDto input);

        Task<UserDto> GetAsync(string id);

        Task<UserDto> GetWithCurrentPackageAsync(string id);

        Task<List<RatingDto>> GetUserRatings(string id);

        Task UpdateAsync(string id, UpdateUserDto input);

        Task<UserDto> AddPackageAsync(CreateUserReadingPackageDto input);

        Task<UserDto> AddHistoryAsync(CreateUserHistoryDto input);

        Task<List<HighlightDto>> AddHighlightAsync(CreateHighlightDto input);

        Task UpdateHighlightAsync(Guid highLightId, UpdateHighlightDto input);

        Task<List<HighlightDto>> GetHighlightsAsync(string userId, string bookId);

        Task<HighlightNotificationDto> GetHighlightNotificationAsync(string userId);

        Task DeleteHighlightAsync(DeleteHighlightDto input);

        Task<List<UserBookDto>> GetReadingBooksAsync(string id);

        Task<List<UserBookDto>> GetFavoriteBooksAsync(string id);

        Task AddReadingBookAsync(CreateUserLibraryDto input);

        Task AddFavoriteBookAsync(CreateUserLibraryDto input);

        Task DeleteFavoriteBookAsync(string userId, string bookId);

        Task UploadImageAsync(string id, string path);

        #region Reminder
        Task<List<ReminderDto>> CreateReminderAsync(CreateReminderDto input);
        Task<List<ReminderDto>> UpdateReminderAsync(string userId, Guid reminderId, UpdateReminderDto input);
        Task<List<ReminderDto>> DeleteReminderAsync(string userId, Guid reminderId);
        Task<List<ReminderDto>> GetRemindersAsync(string userId);
        #endregion
    }
}
