using ApiDemo.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        /// Get Highlights.
        /// </summary>
        /// <remarks>
        /// Get Highlights.
        /// </remarks>
        /// <param name="userId">User Id</param>
        /// <param name="bookId">Book Id</param>
        [HttpGet]
        [Route("{userId}/{bookId}")]
        public async Task<List<HighlightDto>> GetHighlightsAsync([FromRoute] string userId, [FromRoute] string bookId)
        {
            return await _userService.GetHighlightsAsync(userId, bookId);
        }
        /// <summary>
        /// Get Notification Highlight for User.
        /// </summary>
        /// <remarks>
        /// Get Notification Highlight for User.
        /// </remarks>
        /// <param name="userId">User Id</param>
        [HttpGet]
        [Route("{userId}")]
        public async Task<HighlightNotificationDto> GetHighlightNotificationAsync([FromRoute] string userId)
        {
            return await _userService.GetHighlightNotificationAsync(userId);
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
        /// Update Highlight.
        /// </summary>
        /// <remarks>
        /// Update Highlight.
        /// </remarks>
        /// <param name="input">Highlight Infomation</param>
        /// <param name="id">Id</param>
        [HttpPut]
        [Route("{id}")]
        public async Task UpdateHighlightAsync([FromRoute] Guid id, [FromBody] UpdateHighlightDto input)
        {
            await _userService.UpdateHighlightAsync(id, input);
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