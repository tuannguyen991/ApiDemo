using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace ApiDemo.Users
{
    [RemoteService(false)]
    public class UserService : ApiDemoAppService, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager _userManager;

        public UserService(
            IUserRepository userRepository,
            UserManager userManager
        )
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        //     public async Task<UserDto> GetAsync(Guid id)
        //     {
        //         var user = await _userRepository.GetAsync(id);
        //         return ObjectMapper.Map<User, UserDto>(user);
        //     }

        //     public async Task<PagedResultDto<UserDto>> GetListAsync(GetUserListDto input)
        //     {
        //         if (input.Sorting.IsNullOrWhiteSpace())
        //         {
        //             input.Sorting = nameof(User.Name);
        //         }

        //         var users = await _userRepository.GetListAsync(
        //             input.SkipCount,
        //             input.MaxResultCount,
        //             input.Sorting,
        //             input.Filter
        //         );

        //         var totalCount = input.Filter == null
        //             ? await _userRepository.CountAsync()
        //             : await _userRepository.CountAsync(
        //                 user => user.Name.Contains(input.Filter));

        //         return new PagedResultDto<UserDto>(
        //             totalCount,
        //             ObjectMapper.Map<List<User>, List<UserDto>>(users)
        //         );
        //     }

        public async Task<UserDto> CreateAsync(CreateUserDto input)
        {
            var user = await _userManager.CreateAsync(
                input.Username,
                input.Password,
                input.Name,
                input.Email,
                input.BirthDate,
                input.ImageLink
            );

            await _userRepository.InsertAsync(user);

            return ObjectMapper.Map<User, UserDto>(user);
            //     }

            //     public async Task UpdateAsync(Guid id, UpdateUserDto input)
            //     {
            //         var user = await _userRepository.GetAsync(id);

            //         if (user.Name != input.Name)
            //         {
            //             await _userManager.ChangeNameAsync(user, input.Name);
            //         }

            //         user.BirthDate = input.BirthDate;
            //         user.ShortBio = input.ShortBio;

            //         await _userRepository.UpdateAsync(user);
            //     }

            //     public async Task DeleteAsync(Guid id)
            //     {
            //         await _userRepository.DeleteAsync(id);
            //     }
            // 
        }

        public async Task<UserDto> VerifyAsync(VerifyUserDto input)
        {
            var user = await _userManager.VerifyAsync(
                input.Username,
                input.Password
            );

            return ObjectMapper.Map<User, UserDto>(user);
        }

        public async Task UpdateAsync(Guid id, UpdateUserDto input)
        {
            var user = await _userRepository.GetAsync(id);

            // if (user.Name != input.Name)
            // {
            //     await _userManager.ChangeNameAsync(user, input.Name);
            // }

            // user.BirthDate = input.BirthDate;
            // user.ShortBio = input.ShortBio;

            user.Password = input.Password;
            user.Name = input.Name;
            user.Email = input.Email;
            user.BirthDate = input.BirthDate;
            user.ImageLink = input.ImageLink;


            await _userRepository.UpdateAsync(user);
        }
    }
}
