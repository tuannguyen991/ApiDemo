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
            string name,
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
                name,
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

        // public async Task<UserReadingPackage> AddUserReadingPackageAsync(
        //     Guid userId,
        //     Guid readingPackageId
        // )
        // {
        //     var user = await _userRepository.FindAsync(userId);

        //     var duration = new TimeSpan(1, 0, 0, 0);

        //     var userReadingPackage = new UserReadingPackage(
        //         GuidGenerator.Create(),
        //         userId,
        //         readingPackageId,
        //         duration
        //     );

        //     user.CurrentPackage = userReadingPackage;

        //     return userReadingPackage;
        // }
    }
}
