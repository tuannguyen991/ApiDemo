using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ApiDemo.Books;
using ApiDemo.ReadingPackages;
using ApiDemo.Users.RecommendationSystem;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace ApiDemo.Users
{
    [RemoteService(false)]
    public class UserService : ApiDemoAppService, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IReadingPackageRepository _readingPackageRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IBookService _bookService;
        private readonly UserManager _userManager;

        public UserService(
            IUserRepository userRepository,
            IReadingPackageRepository readingPackageRepository,
            IBookRepository bookRepository,
            IBookService bookService,
            UserManager userManager
        )
        {
            _userRepository = userRepository;
            _readingPackageRepository = readingPackageRepository;
            _bookRepository = bookRepository;
            _bookService = bookService;
            _userManager = userManager;
        }

        public async Task<UserDto> CreateAsync(CreateUserDto input)
        {
            var user = await _userManager.CreateAsync(
                input.Id,
                input.FirstName,
                input.LastName,
                input.Email,
                input.BirthDate
            );

            await _userRepository.InsertAsync(user);

            return ObjectMapper.Map<User, UserDto>(user);
        }

        public async Task<UserDto> GetAsync(string id)
        {
            if (id == "null")
            {
                List<string> idsString = await _bookRepository.GetBooksForCalculateTopAsync();

                var recommendDefaultDto = new List<UserBookDto>();

                foreach (var idString in idsString)
                {
                    var bookDto = ObjectMapper.Map<Book, UserBookDto>(await _bookRepository.GetAsync(idString));
                    recommendDefaultDto.Add(bookDto);
                }

                var userDefaultDto = new UserDto();

                userDefaultDto.FirstName = "Khách";
                userDefaultDto.RecommendBooks = recommendDefaultDto;
                userDefaultDto.LastBook = recommendDefaultDto.First();

                return userDefaultDto;
            }

            var items = ObjectMapper.Map<List<Book>, List<ItemDto>>(await _bookRepository.GetItemsAsync());

            var userRatings = await GetUserRatings(id);

            List<string> ids;
            if (userRatings.Count == 0)
            {
                ids = await _bookRepository.GetBooksForCalculateTopAsync();
            }
            else
            {
                var recommendationSystem = new ItemRecommendationSystem(items, userRatings);

                ids = recommendationSystem.GetUserRecommendations();

                if (ids.Count == 0)
                    ids = await _bookRepository.GetBooksForCalculateTopAsync();
            }


            var user = await _userRepository.GetAsync(id);

            var recommendDto = new List<UserBookDto>();

            foreach (var idBook in ids)
            {
                var bookDto = ObjectMapper.Map<Book, UserBookDto>(await _bookRepository.GetAsync(idBook));

                recommendDto.Add(bookDto);
            }

            var userDto = ObjectMapper.Map<User, UserDto>(user);
            userDto.RecommendBooks = recommendDto;
            var readingBooks = await _userRepository.GetReadingBooksAsync(id);
            if (readingBooks.Count > 0)
            {
                var book = ObjectMapper.Map<UserLibrary, UserLibraryDto>(readingBooks.Last());
                var userBookDto = ObjectMapper.Map<Book, UserBookDto>(await _bookRepository.GetAsync(book.BookId));
                userBookDto.UserLibrary = book;
                userDto.LastBook = userBookDto;
            }
            else
            {
                userDto.LastBook = recommendDto.First();
            }

            return userDto;
        }

        public async Task<UserDto> GetWithCurrentPackageAsync(string id)
        {
            var user = await _userRepository.GetAsync(id);

            var userDto = ObjectMapper.Map<User, UserDto>(user);

            return userDto;
        }

        public async Task UpdateAsync(string id, UpdateUserDto input)
        {
            var user = await _userRepository.GetAsync(id);

            user.FirstName = input.FirstName;
            user.LastName = input.LastName;
            user.Email = input.Email;
            user.BirthDate = input.BirthDate;

            await _userRepository.UpdateAsync(user);
        }

        public async Task<UserDto> AddPackageAsync(CreateUserReadingPackageDto input)
        {
            var user = await _userRepository.FindAsync(input.UserId);

            var readingPackage = await _readingPackageRepository.GetAsync(input.ReadingPackageId);

            await _userManager.AddPackageAsync(user, readingPackage.Id, DateTime.Parse(input.StartDate, null, DateTimeStyles.RoundtripKind), TimeSpan.Parse(readingPackage.Duration));

            await _userRepository.UpdateAsync(user);

            return ObjectMapper.Map<User, UserDto>(user);
        }

        public async Task<UserDto> AddHistoryAsync(CreateUserHistoryDto input)
        {
            var user = await _userRepository.GetAsync(input.UserId);

            var history = user.Histories.Find(x => x.Date.Date == input.Date.Date);

            var usageTime = user.UsageTime.Split(';').Select(int.Parse).ToList();
            usageTime[input.Date.Hour] += (int)Math.Ceiling(input.ReadingTime.TotalMinutes);

            user.UsageTime = string.Join(";", usageTime);

            var reminder = user.Reminders.Find(x => x.IsDefault);
            reminder.Time = TimeSpan.FromHours(usageTime.IndexOf(usageTime.Max())).ToString(@"hh\:mm");

            if (history != null)
            {
                history.ReadingTime += input.ReadingTime;
            }
            else
            {
                await _userManager.AddHistoryAsync(user, input.Date, input.ReadingTime);
            }

            await _userRepository.UpdateAsync(user);

            return ObjectMapper.Map<User, UserDto>(user);
        }

        #region Highlights
        public async Task<List<HighlightDto>> GetHighlightsAsync(string userId, string bookId)
        {
            var highlights = await _userRepository.FindHighlightsAsync(userId, bookId);

            foreach (var highlight in highlights)
            {
                highlight.Note = highlight.Note == "null" ? null : highlight.Note;
            }

            return ObjectMapper.Map<List<Highlight>, List<HighlightDto>>(highlights);
        }

        public async Task<HighlightNotificationDto> GetHighlightNotificationAsync(string userId)
        {
            var highlights = await _userRepository.FindHighlightsByUserIdAsync(userId);

            if (highlights.Count == 0)
                throw new EntityNotFoundException();

            Random rand = new Random();
            int index = rand.Next(highlights.Count);
            return ObjectMapper.Map<Highlight, HighlightNotificationDto>(highlights[index]);
        }

        public async Task<List<HighlightDto>> AddHighlightAsync(CreateHighlightDto input)
        {
            var user = await _userRepository.FindAsync(input.UserId);

            await _userManager.AddHighlightAsync(user, input.BookId, input.Content, input.Date, input.Type, input.PageNumber, input.PageId, input.Rangy, input.Uuid, input.Note);

            await _userRepository.UpdateAsync(user);

            return ObjectMapper.Map<List<Highlight>, List<HighlightDto>>(user.Highlights);
        }

        public async Task UpdateHighlightAsync(Guid highLightId, UpdateHighlightDto input)
        {
            var user = await _userRepository.FindAsync(input.UserId);

            await _userManager.UpdateHighlightAsync(user, highLightId, input.Date, input.Type, input.Rangy, input.Note);

            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteHighlightAsync(DeleteHighlightDto input)
        {
            var user = await _userRepository.FindAsync(input.UserId);

            await _userManager.DeleteHighlightAsync(user, input.Id);

            await _userRepository.UpdateAsync(user);
        }
        #endregion
        #region User Library
        public async Task<List<UserBookDto>> GetReadingBooksAsync(string id)
        {
            var readingBooks = ObjectMapper.Map<List<UserLibrary>, List<UserLibraryDto>>(await _userRepository.GetReadingBooksAsync(id));

            return await Convert(readingBooks);
        }

        public async Task<List<UserBookDto>> GetFavoriteBooksAsync(string id)
        {
            var favoriteBooks = ObjectMapper.Map<List<UserLibrary>, List<UserLibraryDto>>(await _userRepository.GetFavoriteBooksAsync(id));

            return await Convert(favoriteBooks);
        }

        public async Task AddReadingBookAsync(CreateUserLibraryDto input)
        {
            var user = await _userRepository.FindAsync(input.UserId);
            var userLibraries = user.UserLibraries;
            var userLibrary = userLibraries.Find(userLibrary => userLibrary.BookId == input.BookId);

            if (userLibrary != null)
            {
                userLibrary.IsReading = true;
                userLibrary.NumberOfReadPages += input.NumberOfReadPages >= 0 ? input.NumberOfReadPages : 0;
                userLibrary.LastRead = DateTime.Now;
                userLibrary.LastLocator = input.LastLocator;
                userLibrary.Href = input.Href;
                userLibrary.ReadCount += 1;
            }
            else
            {
                if (input.NumberOfReadPages > 0)
                    await _userManager.AddReadingBookAsync(user, input.BookId, input.NumberOfReadPages, input.LastLocator, input.Href);
            }
            await _userRepository.UpdateAsync(user);
        }

        public async Task AddFavoriteBookAsync(CreateUserLibraryDto input)
        {
            var user = await _userRepository.FindAsync(input.UserId);
            var userLibraries = user.UserLibraries;
            var userLibrary = userLibraries.Find(userLibrary => userLibrary.BookId == input.BookId);

            if (userLibrary != null)
            {
                userLibrary.IsFavorite = true;
            }
            else
            {
                await _userManager.AddFavoriteBookAsync(user, input.BookId);
            }
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteFavoriteBookAsync(string userId, string bookId)
        {
            var user = await _userRepository.FindAsync(userId);
            var userLibraries = user.UserLibraries;

            var userLibrary = userLibraries.Find(userLibrary => userLibrary.BookId == bookId);

            if (userLibrary.IsReading)
            {
                userLibrary.IsFavorite = false;
            }
            else
            {
                userLibrary.IsFavorite = false;
                userLibraries.RemoveAll(userLibrary => userLibrary.BookId == bookId);
            }
            await _userRepository.UpdateAsync(user);
        }

        public async Task UploadImageAsync(string id, string path)
        {
            var user = await _userRepository.FindAsync(id);

            user.ImageLink = path;

            await _userRepository.UpdateAsync(user);
        }
        #endregion
        #region private method
        private async Task<List<UserBookDto>> Convert(List<UserLibraryDto> books)
        {
            var result = new List<UserBookDto>();
            foreach (var book in books)
            {
                var userBookDto = ObjectMapper.Map<Book, UserBookDto>(await _bookRepository.GetAsync(book.BookId));
                userBookDto.UserLibrary = book;
                result.Add(userBookDto);
            }

            return result;
        }

        public async Task<List<RatingDto>> GetUserRatings(string id)
        {
            var user = await _userRepository.GetAsync(id);

            return ObjectMapper.Map<List<UserLibrary>, List<RatingDto>>(user.UserLibraries);
        }
        #endregion

        #region Reminder
        public async Task<List<ReminderDto>> GetRemindersAsync(string userId)
        {
            var user = await _userRepository.GetWithRemindersAsync(userId);

            return ObjectMapper.Map<List<Reminder>, List<ReminderDto>>(user.Reminders);
        }

        public async Task<List<ReminderDto>> CreateReminderAsync(CreateReminderDto input)
        {
            var user = await _userRepository.GetWithRemindersAsync(input.UserId);

            await _userManager.AddReminderAsync(user, input.Time);

            await _userRepository.UpdateAsync(user);

            return ObjectMapper.Map<List<Reminder>, List<ReminderDto>>(user.Reminders);
        }

        public async Task<List<ReminderDto>> UpdateReminderAsync(string userId, Guid reminderId, UpdateReminderDto input)
        {
            var user = await _userRepository.GetWithRemindersAsync(userId);
            var reminder = user.Reminders.Find(x => x.Id == reminderId);

            reminder.Time = input.Time;

            await _userRepository.UpdateAsync(user);

            return ObjectMapper.Map<List<Reminder>, List<ReminderDto>>(user.Reminders);
        }

        public async Task<List<ReminderDto>> DeleteReminderAsync(string userId, Guid reminderId)
        {
            var user = await _userRepository.GetWithRemindersAsync(userId);
            var reminders = user.Reminders;

            reminders.RemoveAll(x => x.Id == reminderId);

            await _userRepository.UpdateAsync(user);

            return ObjectMapper.Map<List<Reminder>, List<ReminderDto>>(user.Reminders);
        }
        #endregion
    }
}
