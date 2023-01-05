using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using ApiDemo.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ApiDemo.Users
{
    public class EfCoreUserRepository
        : EfCoreRepository<ApiDemoDbContext, User, Guid>,
            IUserRepository
    {
        public EfCoreUserRepository(
            IDbContextProvider<ApiDemoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<User> FindByUsernameAsync(string username)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(user => user.Username == username);
        }

        // public async Task<List<User>> GetListAsync(
        //     int skipCount,
        //     int maxResultCount,
        //     string sorting,
        //     string filter = null)
        // {
        //     var dbSet = await GetDbSetAsync();
        //     return await dbSet
        //         .WhereIf(
        //             !filter.IsNullOrWhiteSpace(),
        //             user => user.Name.Contains(filter)
        //          )
        //         .OrderBy(sorting)
        //         .Skip(skipCount)
        //         .Take(maxResultCount)
        //         .ToListAsync();
        // }

        // protected override IQueryable<User> CreateFilteredQuery( input)
        // {
        //     // return Repository.GetAllIncluding(x => x.Categories, x => x.ThumbnailImage, x => x.ProductGroup);
        // }
    }
}
