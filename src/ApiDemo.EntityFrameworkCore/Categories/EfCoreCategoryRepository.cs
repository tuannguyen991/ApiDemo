using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using ApiDemo.Categories;
using ApiDemo.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ApiDemo.Categories
{
    public class EfCoreCategoryRepository
        : EfCoreRepository<ApiDemoDbContext, Category, Guid>,
            ICategoryRepository
    {
        public EfCoreCategoryRepository(
            IDbContextProvider<ApiDemoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<Category> FindByNameAsync(string name)
        {
            var queryable = await WithDetailsAsync();

            var query = queryable.Where(category => category.Name == name);

            return await AsyncExecuter.FirstOrDefaultAsync(query);
        }

        public async Task<List<Category>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    author => author.Name.ToLower().Contains(filter.ToLower())
                 )
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
