using ApiDemo.Books;
using ApiDemo.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDemo.Controllers
{
    [ApiController]
    [Route("api/v1/books")]
    public class BookController : ApiDemoController
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        #region CRUD
        /// <summary>
        /// Get categories list with paged result.
        /// </summary>
        /// <remarks>
        /// Get categories list with paged result.
        /// </remarks>
        /// <param name="input">Paged Condition</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<BookDto>> GetListAsync([FromQuery] GetBookListDto input)
        {
            return await _bookService.GetListAsync(input);
        }
        /// <summary>
        /// Get book by Id.
        /// </summary>
        /// <remarks>
        /// Get book by Id.
        /// </remarks>
        /// <param name="id">Book Id</param>
        [HttpGet]
        [Route("{id}")]
        public async Task<BookDto> GetAsync([FromRoute] string id)
        {
            return await _bookService.GetAsync(id);
        }
        /// <summary>
        /// Delete book by Id.
        /// </summary>
        /// <remarks>
        /// Delete book by Id.
        /// </remarks>
        /// <param name="id">Book Id</param>
        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteAsync([FromRoute] string id)
        {
            await _bookService.DeleteAsync(id);
        }
        /// <summary>
        /// Create book.
        /// </summary>
        /// <remarks>
        /// Create book.
        /// </remarks>
        /// <param name="input">Book Infomation</param>
        [HttpPost]
        public async Task<BookDto> CreateAsync([FromBody] CreateBookDto input)
        {
            return await _bookService.CreateAsync(input);
        }
        /// <summary>
        /// Update book by Id.
        /// </summary>
        /// <remarks>
        /// Update book.
        /// </remarks>
        /// <param name="id">Book Id</param>
        /// <param name="input">Book Infomation</param>
        [HttpPut]
        [Route("{id}")]
        public async Task UpdateAsync([FromRoute] string id, [FromBody] UpdateBookDto input)
        {
            await _bookService.UpdateAsync(id, input);
        }
        #endregion

        #region User relevant
        /// <summary>
        /// GetListByCategoryId.
        /// </summary>
        /// <remarks>
        /// GetListByCategoryId.
        /// </remarks>
        /// <param name="categoryId">Category Id</param>
        /// <param name="userId">User Id</param>
        [HttpGet]
        [Route("by-category/{userId}/{categoryId}")]
        public async Task<List<UserBookDto>> GetListByCategoryIdAsync([FromRoute] string userId, [FromRoute] Guid categoryId)
        {
            return await _bookService.GetListByCategoryIdAsync(userId, categoryId);
        }
        /// <summary>
        /// GetListByAuthorIdAsync.
        /// </summary>
        /// <remarks>
        /// GetListByAuthorIdAsync.
        /// </remarks>
        /// <param name="authorId">Author Id</param>
        /// <param name="userId">User Id</param>
        [HttpGet]
        [Route("by-author/{userId}/{authorId}")]
        public async Task<List<UserBookDto>> GetListByAuthorIdAsync([FromRoute] string userId, [FromRoute] Guid authorId)
        {
            return await _bookService.GetListByAuthorIdAsync(userId, authorId);
        }
        /// <summary>
        /// GetBookByNameAsync.
        /// </summary>
        /// <remarks>
        /// GetBookByNameAsync.
        /// </remarks>
        /// <param name="userId">User Id</param>
        /// <param name="input">User Id</param>
        [HttpGet]
        [Route("by-name/{userId}")]
        public async Task<List<UserBookDto>> GetBookByNameAsync([FromRoute] string userId, [FromQuery] GetBookListDto input)
        {
            return await _bookService.GetBookByNameAsync(userId, input);
        }
        /// <summary>
        /// GetTopBooksAsync.
        /// </summary>
        /// <remarks>
        /// GetTopBooksAsync.
        /// </remarks>
        /// <param name="userId">User Id</param>
        [HttpGet]
        [Route("top-books/{userId}")]
        public async Task<List<UserBookDto>> GetTopBooksAsync([FromRoute] string userId)
        {
            return await _bookService.GetTopBooksAsync(userId);
        }
        #endregion
    }
}