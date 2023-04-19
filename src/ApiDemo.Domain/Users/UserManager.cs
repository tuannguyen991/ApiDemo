using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using Volo.Abp.Validation;

namespace ApiDemo.Users
{
    public class UserManager : DomainService
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User> CreateAsync(
            string id,
            string firstName,
            string lastName,
            string email,
            DateTime birthDate
        )
        {
            return Task.FromResult(
                new User(
                id,
                firstName,
                lastName,
                email,
                birthDate
            ));
        }

        public Task AddPackageAsync(
            User user, 
            Guid readingPackageId,
            DateTime startDate,
            TimeSpan duration
        )
        {
            var userReadingPackage = new UserReadingPackage(
                GuidGenerator.Create(),
                user.Id,
                readingPackageId,
                startDate,
                duration
            );

            user.Packages.Add(userReadingPackage);
            return Task.CompletedTask;
        }

        public Task AddHistoryAsync(
            User user, 
            DateTime date,
            TimeSpan readingTime
        )
        {
            var userHistory = new UserHistory(
                GuidGenerator.Create(),
                user.Id,
                date,
                readingTime
            );

            user.Histories.Add(userHistory);
            return Task.CompletedTask;
        }

        #region Highlight
        public Task AddHighlightAsync(
            User user, 
            string bookId,
            string content,
            DateTime date,
            string type,
            int pageNumber,
            string pageId,
            string rangy,
            string uuid,
            string note
        )
        {
            var highlight = new Highlight(
                user.Id,
                bookId,
                content,
                date,
                type,
                pageNumber,
                pageId,
                rangy,
                uuid,
                note
            );

            user.Highlights.Add(highlight);
            return Task.CompletedTask;
        }

        public Task DeleteHighlightAsync(
            User user, 
            Guid id
        )
        {
            var index = user.Highlights.FindIndex(highlight => highlight.Id == id);

            user.Highlights.RemoveAt(index);

            return Task.CompletedTask;
        }
        #endregion

        #region User Library
        public Task AddReadingBookAsync(
            User user, 
            string bookId,
            int numberOfReadPages,
            string lastLocator,
            string href
        )
        {
            var isReading = true;
            var isFavorite = false;

            var readingBook = new UserLibrary(
                GuidGenerator.Create(),
                user.Id,
                bookId,
                isFavorite,
                isReading,
                numberOfReadPages,
                DateTime.Now,
                lastLocator,
                href
            );

            user.UserLibraries.Add(readingBook);
            return Task.CompletedTask;
        }

        public Task AddFavoriteBookAsync(
            User user, 
            string bookId
        )
        {
            var numberOfReadPages = 0;
            
            var isReading = false;
            var isFavorite = true;

            var favoriteBook = new UserLibrary(
                GuidGenerator.Create(),
                user.Id,
                bookId,
                isFavorite,
                isReading,
                numberOfReadPages,
                null,
                null,
                null
            );

            user.UserLibraries.Add(favoriteBook);
            return Task.CompletedTask;
        }
        #endregion
    }
}
