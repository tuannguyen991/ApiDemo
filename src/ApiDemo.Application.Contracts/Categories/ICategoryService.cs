using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ApiDemo.Categories
{
    public interface ICategoryService : IApplicationService
    {
        Task<CategoryDto> GetAsync(Guid id);

        Task<List<CategoryDto>> GetListAsync(GetCategoryListDto input);

        Task<CategoryDto> CreateAsync(CreateCategoryDto input);

        Task UpdateAsync(Guid id, UpdateCategoryDto input);

        Task DeleteAsync(Guid id);
    }
}
