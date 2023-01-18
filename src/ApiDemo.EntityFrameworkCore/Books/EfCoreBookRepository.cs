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
                            book => book.Title.ToLower().Contains(filter.ToLower())
                        )
                        .OrderBy(sorting)
                        .Skip(skipCount)
                        .Take(maxResultCount);

            return await query.ToListAsync();
        }

        public async Task<List<Book>> GetListByAuthorIdAsync(Guid authorId)
        {
            var queryable = await WithDetailsAsync();

            var query = queryable.Where(
                            book => book.Authors.Any(author => author.AuthorId == authorId)
                        );

            return await query.ToListAsync();        
        }

        public async Task<List<Book>> GetListByCategoryIdAsync(Guid categoryId)
        {
            var queryable = await WithDetailsAsync();

            var query = queryable.Where(
                            book => book.Categories.Any(category => category.CategoryId == categoryId)
                        );

            return await query.ToListAsync(); 
        }
    }
}
