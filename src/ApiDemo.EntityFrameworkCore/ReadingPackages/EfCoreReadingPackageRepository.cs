using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using ApiDemo.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ApiDemo.ReadingPackages
{
    public class EfCoreReadingPackageRepository
        : EfCoreRepository<ApiDemoDbContext, ReadingPackage, Guid>,
            IReadingPackageRepository
    {
        public EfCoreReadingPackageRepository(
            IDbContextProvider<ApiDemoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<List<ReadingPackage>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    readingPackage => readingPackage.Name.Contains(filter)
                 )
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }

        // protected override IQueryable<ReadingPackage> CreateFilteredQuery( input)
        // {
        //     // return Repository.GetAllIncluding(x => x.Categories, x => x.ThumbnailImage, x => x.ProductGroup);
        // }
    }
}
