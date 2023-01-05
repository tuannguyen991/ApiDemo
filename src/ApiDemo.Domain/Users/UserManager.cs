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
    }
}
