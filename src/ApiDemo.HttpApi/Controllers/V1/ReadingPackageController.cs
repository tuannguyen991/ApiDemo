using ApiDemo.ReadingPackages;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDemo.Controllers
{
    [ApiController]
    [Route("api/v1/reading-packages")]
    public class ReadingPackageController : ApiDemoController
    {
        private readonly IReadingPackageService _readingPackageService;
        public ReadingPackageController(IReadingPackageService readingPackageService)
        {
            _readingPackageService = readingPackageService;
        }
        /// <summary>
        /// Get readingPackages list with paged result.
        /// </summary>
        /// <remarks>
        /// Get readingPackages list with paged result.
        /// </remarks>
        /// <param name="input">Paged Condition</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<ReadingPackageDto>> GetListAsync([FromQuery] GetReadingPackageListDto input)
        {
            return await _readingPackageService.GetListAsync(input);
        }
        /// <summary>
        /// Get readingPackage by Id.
        /// </summary>
        /// <remarks>
        /// Get readingPackage by Id.
        /// </remarks>
        /// <param name="id">ReadingPackage Id</param>
        [HttpGet]
        [Route("{id}")]
        public async Task<ReadingPackageDto> GetAsync([FromRoute] Guid id)
        {
            return await _readingPackageService.GetAsync(id);
        }
        /// <summary>
        /// Delete readingPackage by Id.
        /// </summary>
        /// <remarks>
        /// Delete readingPackage by Id.
        /// </remarks>
        /// <param name="id">ReadingPackage Id</param>
        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteAsync([FromRoute] Guid id)
        {
            await _readingPackageService.DeleteAsync(id);
        }

        /// <summary>
        /// Update information readingPackage.
        /// </summary>
        /// <remarks>
        /// Update information readingPackage.
        /// </remarks>
        /// <param name="id">Id ReadingPackage</param>
        /// <param name="input">Update ReadingPackage Infomation</param>
        [HttpPut]
        [Route("{id}")]
        public async Task UpdateAsync([FromRoute] Guid id, [FromBody] UpdateReadingPackageDto input)
        {
            await _readingPackageService.UpdateAsync(id, input);
        }

        /// <summary>
        /// Create ReadingPackage.
        /// </summary>
        /// <remarks>
        /// Create ReadingPackage.
        /// </remarks>
        /// <param name="input">ReadingPackage Infomation</param>
        [HttpPost]
        public async Task<ReadingPackageDto> CreateAsync([FromBody] CreateReadingPackageDto input)
        {
            return await _readingPackageService.CreateAsync(input);
        }
    }
}