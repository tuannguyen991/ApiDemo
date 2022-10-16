using ApiDemo.Books;
using Microsoft.AspNetCore.Mvc;
using System;
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
        /// Get authors list with paged result.
        /// </summary>
        /// <remarks>
        /// Get authors list with paged result.
        /// </remarks>
        /// <param name="input">Paged Condition</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PagedResultDto<BookDto>> GetListAsync([FromQuery] GetBookListDto input)
        {
            return await _bookService.GetListAsync(input);
        }
        /// <summary>
        /// Get author by Id.
        /// </summary>
        /// <remarks>
        /// Get author by Id.
        /// </remarks>
        /// <param name="id">Author Id</param>
        [HttpGet]
        [Route("{id}")]
        public async Task<BookDto> GetAsync([FromRoute] Guid id)
        {
            return await _bookService.GetAsync(id);
        }
        /// <summary>
        /// Delete author by Id.
        /// </summary>
        /// <remarks>
        /// Delete author by Id.
        /// </remarks>
        /// <param name="id">Author Id</param>
        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteAsync([FromRoute] Guid id)
        {
            await _bookService.DeleteAsync(id);
        }
        /// <summary>
        /// Create author.
        /// </summary>
        /// <remarks>
        /// Create author.
        /// </remarks>
        /// <param name="input">Author Infomation</param>
        [HttpPost]
        public async Task<BookDto> CreateAsync([FromBody] CreateBookDto input)
        {
            return await _bookService.CreateAsync(input);
        }
        /// <summary>
        /// Update author by Id.
        /// </summary>
        /// <remarks>
        /// Update author.
        /// </remarks>
        /// <param name="id">Author Id</param>
        /// <param name="input">Author Infomation</param>
        [HttpPut]
        [Route("{id}")]
        public async Task UpdateAsync([FromRoute] Guid id, [FromBody] UpdateBookDto input)
        {
            await _bookService.UpdateAsync(id, input);
        }
    }
}