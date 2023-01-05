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
        // / <summary>
        // / Get users list with paged result.
        // / </summary>
        // / <remarks>
        // / Get users list with paged result.
        // / </remarks>
        // / <param name="input">Paged Condition</param>
        // / <returns></returns>
        // [HttpGet]
        // public async Task<PagedResultDto<UserDto>> GetListAsync([FromQuery] GetUserListDto input)
        // {
        //     return await _userService.GetListAsync(input);
        // }
        // /// <summary>
        // /// Get user by Id.
        // /// </summary>
        // /// <remarks>
        // /// Get user by Id.
        // /// </remarks>
        // /// <param name="id">User Id</param>
        // [HttpGet]
        // [Route("{id}")]
        // public async Task<UserDto> GetAsync([FromRoute] Guid id)
        // {
        //     return await _userService.GetAsync(id);
        // }
        // /// <summary>
        // /// Delete user by Id.
        // /// </summary>
        // /// <remarks>
        // /// Delete user by Id.
        // /// </remarks>
        // /// <param name="id">User Id</param>
        // [HttpDelete]
        // [Route("{id}")]
        // public async Task DeleteAsync([FromRoute] Guid id)
        // {
        //     await _userService.DeleteAsync(id);
        // }
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


        // /// <summary>
        // /// Update user by Id.
        // /// </summary>
        // /// <remarks>
        // /// Update user.
        // /// </remarks>
        // /// <param name="id">User Id</param>
        // /// <param name="input">User Infomation</param>
        // [HttpPut]
        // [Route("{id}")]
        // public async Task UpdateAsync([FromRoute] Guid id, [FromBody] UpdateUserDto input)
        // {
        //     await _userService.UpdateAsync(id, input);
        // }
    }
}