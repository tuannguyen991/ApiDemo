using ApiDemo.Authors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ApiDemo.Controllers
{
    [ApiController]
    [Route("api/v1/authors")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<PagedResultDto<AuthorDto>> GetListAsync([FromQuery] GetAuthorListDto input)
        {
            return await _authorService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<AuthorDto> GetAsync([FromRoute] Guid id)
        {
            return await _authorService.GetAsync(id);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteAsync([FromRoute] Guid id)
        {
            await _authorService.DeleteAsync(id);
        }

        [HttpPost]
        public async Task<AuthorDto> CreateAsync([FromBody] CreateAuthorDto input)
        {
            return await _authorService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task UpdateAsync([FromRoute] Guid id, [FromBody] UpdateAuthorDto input)
        {
            await _authorService.UpdateAsync(id, input);
        }
    }
}