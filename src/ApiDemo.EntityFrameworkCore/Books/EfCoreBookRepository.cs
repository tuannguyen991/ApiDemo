using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using ApiDemo.Books;
using ApiDemo.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ApiDemo.Books
{
    public class EfCoreBookRepository
        : EfCoreRepository<ApiDemoDbContext, Book, Guid>,
            IBookRepository
    {
        public EfCoreBookRepository(
            IDbContextProvider<ApiDemoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<Book> FindByTitleAsync(string title)
        {
            var queryable = await WithDetailsAsync();

            var query = queryable.Where(book => book.Title == title);

            return await AsyncExecuter.FirstOrDefaultAsync(query);
        }

        public async Task<List<Book>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null)
        {
            var queryable = await WithDetailsAsync();

            var query = queryable.WhereIf(
                            !filter.IsNullOrWhiteSpace(),
                            author => author.Title.Contains(filter)
                        )
                        .OrderBy(sorting)
                        .Skip(skipCount)
                        .Take(maxResultCount);


            // var dbSet = await GetDbSetAsync();
            return await query.ToListAsync();
        }
    }
}
