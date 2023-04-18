using ApiDemo.Books;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

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
        /// Get categories list by Category Id.
        /// </summary>
        /// <remarks>
        /// Get categories list by Category Id.
        /// </remarks>
        /// <param name="cagoryId">Category Id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("by-category/{cagoryId}")]
        public async Task<List<BookDto>> GetListByCategoryIdAsync([FromRoute] Guid cagoryId)
        {
            return await _bookService.GetListByCategoryIdAsync(cagoryId);
        }
        /// <summary>
        /// Get categories list by Author Id.
        /// </summary>
        /// <remarks>
        /// Get categories list by Author Id.
        /// </remarks>
        /// <param name="authorId">Author Id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("by-author/{authorId}")]
        public async Task<List<BookDto>> GetListByAuthorIdAsync([FromRoute] Guid authorId)
        {
            return await _bookService.GetListByAuthorIdAsync(authorId);
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
    }
}