using ApiDemo.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ApiDemo.Controllers
{
    [ApiController]
    [Route("api/v1/highlights")]
    public class HighlightController : ApiDemoController
    {
        private readonly IUserService _userService;
        public HighlightController(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// Get Highlight.
        /// </summary>
        /// <remarks>
        /// Get Highlight.
        /// </remarks>
        /// <param name="input">Highlight Infomation</param>
        [HttpGet]
        public async Task<List<HighlightDto>> GetHighlightsAsync([FromQuery] GetHighlightDto input)
        {
            return await _userService.GetHighlightsAsync(input);
        }
        /// <summary>
        /// Add Highlight.
        /// </summary>
        /// <remarks>
        /// Add Highlight.
        /// </remarks>
        /// <param name="input">Highlight Infomation</param>
        [HttpPost]
        public async Task<List<HighlightDto>> AddHighlightAsync([FromBody] CreateHighlightDto input)
        {
            return await _userService.AddHighlightAsync(input);
        }
        /// <summary>
        /// Delete Highlight.
        /// </summary>
        /// <remarks>
        /// Delete Highlight.
        /// </remarks>
        /// <param name="input">Highlight Infomation</param>
        [HttpDelete]
        public async Task DeleteHighlightAsync([FromBody] DeleteHighlightDto input)
        {
            await _userService.DeleteHighlightAsync(input);
        }
    }
}