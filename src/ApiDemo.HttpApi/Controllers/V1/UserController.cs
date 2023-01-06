using ApiDemo.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ApiDemo.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserController : ApiDemoController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// Create user.
        /// </summary>
        /// <remarks>
        /// Create user.
        /// </remarks>
        /// <param name="input">User Infomation</param>
        [HttpPost]
        public async Task<UserDto> CreateAsync([FromBody] CreateUserDto input)
        {
            return await _userService.CreateAsync(input);
        }
        /// <summary>
        /// Verify user.
        /// </summary>
        /// <remarks>
        /// Verify user.
        /// </remarks>
        /// <param name="input">Verify User Infomation</param>
        [HttpPost]
        [Route("verify")]
        public async Task<UserDto> VerifyAsync([FromBody] VerifyUserDto input)
        {
            return await _userService.VerifyAsync(input);
        }
        /// <summary>
        /// Update information user.
        /// </summary>
        /// <remarks>
        /// Update information user.
        /// </remarks>
        /// <param name="id">Id User</param>
        /// <param name="input">Update User Infomation</param>
        [HttpPut]
        [Route("{id}")]
        public async Task UpdateAsync([FromRoute] Guid id, [FromBody] UpdateUserDto input)
        {
            await _userService.UpdateAsync(id, input);
        }
        /// <summary>
        /// Add Reading Package.
        /// </summary>
        /// <remarks>
        /// Add Reading Package.
        /// </remarks>
        /// <param name="input">Package Infomation</param>
        [HttpPost]
        [Route("add-reading-package")]
        public async Task<UserDto> AddPackageAsync([FromBody] CreateUserReadingPackageDto input)
        {
            return await _userService.AddPackageAsync(input);
        }
        /// <summary>
        /// Add History User.
        /// </summary>
        /// <remarks>
        /// Add History User.
        /// </remarks>
        /// <param name="input">History Infomation</param>
        [HttpPost]
        [Route("add-history")]
        public async Task<UserDto> AddHistoryAsync([FromBody] CreateUserHistoryDto input)
        {
            return await _userService.AddHistoryAsync(input);
        }
    }
}