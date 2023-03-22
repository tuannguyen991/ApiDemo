using ApiDemo.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        public async Task<Guid> VerifyAsync([FromBody] VerifyUserDto input)
        {
            return await _userService.VerifyAsync(input);
        }
        /// <summary>
        /// Get user information.
        /// </summary>
        /// <remarks>
        /// Get user information.
        /// </remarks>
        /// <param name="id">User Id</param>
        [HttpGet]
        [Route("{id}")]
        public async Task<UserDto> GetAsync([FromRoute] Guid id)
        {
            return await _userService.GetAsync(id);
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
        [Route("reading-package")]
        public async Task<UserDto> AddPackageAsync([FromBody] CreateUserReadingPackageDto input)
        {
            return await _userService.AddPackageAsync(input);
        }
        /// <summary>
        /// Get Current Reading Package.
        /// </summary>
        /// <remarks>
        /// Get Current Reading Package.
        /// </remarks>
        /// <param name="userId">User ID</param>
        [HttpGet]
        [Route("reading-package/{userId}")]
        public async Task<UserReadingPackageDto> GetUserReadingPackageAsync([FromRoute] Guid userId)
        {
            return await _userService.GetUserReadingPackageAsync(userId);
        }
        /// <summary>
        /// Add History User.
        /// </summary>
        /// <remarks>
        /// Add History User.
        /// </remarks>
        /// <param name="input">History Infomation</param>
        [HttpPost]
        [Route("history")]
        public async Task<UserDto> AddHistoryAsync([FromBody] CreateUserHistoryDto input)
        {
            return await _userService.AddHistoryAsync(input);
        }
        #region User library
        /// <summary>
        /// Get Reading Books.
        /// </summary>
        /// <remarks>
        /// Get Reading Books.
        /// </remarks>
        /// <param name="id">User ID</param>
        [HttpGet]
        [Route("reading-books/{id}")]
        public async Task<List<UserLibraryDto>> GetReadingBooksAsync([FromRoute] Guid id)
        {
            return await _userService.GetReadingBooksAsync(id);
        }
        /// <summary>
        /// Create Reading Books.
        /// </summary>
        /// <remarks>
        /// Create Reading Books.
        /// </remarks>
        /// <param name="input">Reading Book Info</param>
        [HttpPost]
        [Route("reading-books")]
        public async Task AddReadingBookAsync([FromBody] CreateUserLibraryDto input)
        {
            await _userService.AddReadingBookAsync(input);
        }
        /// <summary>
        /// Get Favorite Books.
        /// </summary>
        /// <remarks>
        /// Get Favorite Books.
        /// </remarks>
        /// <param name="id">User ID</param>
        [HttpGet]
        [Route("favorite-books/{id}")]
        public async Task<List<UserLibraryDto>> GetFavoriteBooksAsync([FromRoute] Guid id)
        {
            return await _userService.GetFavoriteBooksAsync(id);
        }
        /// <summary>
        /// Create Favorite Books.
        /// </summary>
        /// <remarks>
        /// Create Favorite Books.
        /// </remarks>
        /// <param name="input">Favorite Book Info</param>
        [HttpPost]
        [Route("favorite-books")]
        public async Task AddFavoriteBookAsync([FromBody] CreateUserLibraryDto input)
        {
            await _userService.AddFavoriteBookAsync(input);
        }
        #endregion
  
    }
}