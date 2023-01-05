using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace ApiDemo.Categories
{
    public class CategoryManager : DomainService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<Category> CreateAsync(
            string name,
            string imageLink
        )
        {
            return Task.FromResult(new Category(
                GuidGenerator.Create(),
                name,
                imageLink
            ));
        }
    }
}
