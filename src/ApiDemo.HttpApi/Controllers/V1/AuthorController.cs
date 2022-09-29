using ApiDemo.Authors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ApiDemo.Controllers
{
    [ApiController]
    [Route("api/v1/authors")]
    public class AuthorController : ApiDemoController
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
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
        public async Task<PagedResultDto<AuthorDto>> GetListAsync([FromQuery] GetAuthorListDto input)
        {
            return await _authorService.GetListAsync(input);
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
        public async Task<AuthorDto> GetAsync([FromRoute] Guid id)
        {
            return await _authorService.GetAsync(id);
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
            await _authorService.DeleteAsync(id);
        }
        /// <summary>
        /// Create author.
        /// </summary>
        /// <remarks>
        /// Create author.
        /// </remarks>
        /// <param name="input">Author Infomation</param>
        [HttpPost]
        public async Task<AuthorDto> CreateAsync([FromBody] CreateAuthorDto input)
        {
            return await _authorService.CreateAsync(input);
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
        public async Task UpdateAsync([FromRoute] Guid id, [FromBody] UpdateAuthorDto input)
        {
            await _authorService.UpdateAsync(id, input);
        }
    }
}