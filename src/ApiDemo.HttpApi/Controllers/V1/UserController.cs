using ApiDemo.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

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
        /// Get user information.
        /// </summary>
        /// <remarks>
        /// Get user information.
        /// </remarks>
        /// <param name="id">User Id</param>
        [HttpGet]
        [Route("{id}")]
        public async Task<UserDto> GetAsync([FromRoute] string id)
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
        public async Task UpdateAsync([FromRoute] string id, [FromBody] UpdateUserDto input)
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
        public async Task<List<UserLibraryDto>> GetReadingBooksAsync([FromRoute] string id)
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
        public async Task<List<UserLibraryDto>> GetFavoriteBooksAsync([FromRoute] string id)
        {
            return await _userService.GetFavoriteBooksAsync(id);
        }
        /// <summary>
        /// Get is Favorite.
        /// </summary>
        /// <remarks>
        /// Get is Favorite.
        /// </remarks>
        /// <param name="id">User ID</param>
        /// <param name="bookId">Book ID</param>
        [HttpGet]
        [Route("favorite/{id}/{bookId}")]
        public async Task<bool> GetIsFavoriteAsync([FromRoute] string id, [FromRoute] string bookId)
        {
            return await _userService.GetIsFavoriteAsync(id, bookId);
        }
        /// <summary>
        /// Get Library Book.
        /// </summary>
        /// <remarks>
        /// Get is Favorite.
        /// </remarks>
        /// <param name="id">User ID</param>
        /// <param name="bookId">Book ID</param>
        [HttpGet]
        [Route("library-book/{id}/{bookId}")]
        public async Task<UserLibraryDto> GetLibraryBookAsync([FromRoute] string id, [FromRoute] string bookId)
        {
            return await _userService.GetLibraryBookAsync(id, bookId);
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
        /// <summary>
        /// Delete Favorite Books.
        /// </summary>
        /// <remarks>
        /// Delete Favorite Books.
        /// </remarks>
        /// <param name="userId">User Id</param>
        /// <param name="bookId">Book Id</param>
        [HttpDelete]
        [Route("favorite-books/{userId}/{bookId}")]
        public async Task DeleteFavoriteBookAsync([FromRoute] string userId, [FromRoute] string bookId)
        {
            await _userService.DeleteFavoriteBookAsync(userId, bookId);
        }
        #endregion

        /// <summary>
        /// Upload image.
        /// </summary>
        /// <remarks>
        /// Upload image.
        /// </remarks>
        /// <param name="id">Id User</param>
        /// <param name="file">Image File</param>
        [HttpPost]
        [Route("{id}/image")]
        public async Task<IActionResult> UploadImage([FromRoute] string id, IFormFile file)
        {
            // Save the image file to the file system
            var filename = Path.GetFileName(file.FileName);
            var directory = Path.Combine("Content", $"Images\\{id}");
            var path = Path.Combine(directory, filename);

            // Create the directory if it does not exist
            Directory.CreateDirectory(directory);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // var user = await _userService.GetAsync(userId);
            await _userService.UploadImageAsync(id, path);

            return Ok("Image uploaded successfully.");
        }

        [HttpGet]
        [Route("images/{path}")]
        public IActionResult GetImage(string path)
        {
            // Check if the requested file exists on the file system
            var filePath = Path.Combine(path);
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("Image not found.");
            }

            // Set the content type of the response to the MIME type of the image file
            var contentType = GetContentType(filePath);
            if (contentType == null)
            {
                return StatusCode(500, "Failed to determine content type of the image file.");
            }
            HttpContext.Response.ContentType = contentType;

            // Return the image file as a stream in the response body
            var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            return new FileStreamResult(stream, contentType);
        }

        private string GetContentType(string filePath)
        {
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filePath, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }
    }
}