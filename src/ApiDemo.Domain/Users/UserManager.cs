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
            string username,
            string password,
            string firstName,
            string lastName,
            string email,
            DateTime birthDate,
            string imageLink
        )
        {
            return Task.FromResult(
                new User(
                GuidGenerator.Create(),
                username,
                password,
                firstName,
                lastName,
                email,
                birthDate,
                imageLink
            ));
        }

        public async Task<User> VerifyAsync(
            string username,
            string password
        )
        {
            var existingUser = await _userRepository.FindByUsernameAsync(username);
            if (existingUser == null)
            {
                throw new AbpValidationException();  
            }

            if (existingUser.Password != password)
            {
                throw new AbpValidationException();
            }

            return existingUser;
        }

        public Task AddPackageAsync(
            User user, 
            Guid readingPackageId,
            TimeSpan duration
        )
        {
            var userReadingPackage = new UserReadingPackage(
                GuidGenerator.Create(),
                user.Id,
                readingPackageId,
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
            Guid bookId,
            DateTime date,
            string location,
            string color,
            string note
        )
        {
            var highlight = new Highlight(
                GuidGenerator.Create(),
                user.Id,
                bookId,
                date,
                location,
                color,
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
            Guid bookId,
            int numberOfReadPages
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
                DateTime.Now
            );

            user.UserLibraries.Add(readingBook);
            return Task.CompletedTask;
        }

        public Task AddFavoriteBookAsync(
            User user, 
            Guid bookId
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
                null
            );

            user.UserLibraries.Add(favoriteBook);
            return Task.CompletedTask;
        }
        #endregion
    }
}
