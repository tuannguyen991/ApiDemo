using ApiDemo.Categories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDemo.Controllers
{
    [ApiController]
    [Route("api/v1/categories")]
    public class CategoryController : ApiDemoController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
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
        public async Task<List<CategoryDto>> GetListAsync([FromQuery] GetCategoryListDto input)
        {
            return await _categoryService.GetListAsync(input);
        }
        /// <summary>
        /// Get category by Id.
        /// </summary>
        /// <remarks>
        /// Get category by Id.
        /// </remarks>
        /// <param name="id">Category Id</param>
        [HttpGet]
        [Route("{id}")]
        public async Task<CategoryDto> GetAsync([FromRoute] Guid id)
        {
            return await _categoryService.GetAsync(id);
        }
        /// <summary>
        /// Delete category by Id.
        /// </summary>
        /// <remarks>
        /// Delete category by Id.
        /// </remarks>
        /// <param name="id">Category Id</param>
        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteAsync([FromRoute] Guid id)
        {
            await _categoryService.DeleteAsync(id);
        }
        /// <summary>
        /// Create category.
        /// </summary>
        /// <remarks>
        /// Create category.
        /// </remarks>
        /// <param name="input">Category Infomation</param>
        [HttpPost]
        public async Task<CategoryDto> CreateAsync([FromBody] CreateCategoryDto input)
        {
            return await _categoryService.CreateAsync(input);
        }
        /// <summary>
        /// Update category by Id.
        /// </summary>
        /// <remarks>
        /// Update category.
        /// </remarks>
        /// <param name="id">Category Id</param>
        /// <param name="input">Category Infomation</param>
        [HttpPut]
        [Route("{id}")]
        public async Task UpdateAsync([FromRoute] Guid id, [FromBody] UpdateCategoryDto input)
        {
            await _categoryService.UpdateAsync(id, input);
        }
    }
}