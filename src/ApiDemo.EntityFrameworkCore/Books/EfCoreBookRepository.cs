using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using ApiDemo.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ApiDemo.Books
{
    public class EfCoreBookRepository
        : EfCoreRepository<ApiDemoDbContext, Book, string>,
            IBookRepository
    {
        public EfCoreBookRepository(
            IDbContextProvider<ApiDemoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<Book> FindByTitleAsync(string title)
        {
            var dbSet = await GetDbSetAsync();

            var query = dbSet.Where(book => book.Title == title);

            query = query
                        .Include(x => x.BookWithAuthors)
                            .ThenInclude(x => x.Author)
                        .Include(x => x.BookWithCategories)
                            .ThenInclude(x => x.Category);

            return await AsyncExecuter.FirstOrDefaultAsync(query);
        }

        public async Task<Book> GetAsync(string id)
        {
            var dbSet = await GetDbSetAsync();

            var query = dbSet.Where(book => book.Id == id);

            query = query
                        .Include(x => x.BookWithAuthors)
                            .ThenInclude(x => x.Author)
                        .Include(x => x.BookWithCategories)
                            .ThenInclude(x => x.Category);

            return await AsyncExecuter.FirstOrDefaultAsync(query);
        }

        public async Task<List<Book>> GetItemsAsync()
        {
            var dbSet = await GetDbSetAsync();

            var query = dbSet
                        .Include(x => x.BookWithCategories)
                            .ThenInclude(x => x.Category);

            return await query.ToListAsync();
        }

        public async Task<List<Book>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null)
        {
            var dbSet = await GetDbSetAsync();

            var query = dbSet.WhereIf(
                            !filter.IsNullOrWhiteSpace(),
                            book => book.Title.ToLower().Contains(filter.ToLower())
                        )
                        .OrderBy(sorting)
                        .Skip(skipCount)
                        .Take(maxResultCount);

            query = query
                        .Include(x => x.BookWithAuthors)
                            .ThenInclude(x => x.Author)
                        .Include(x => x.BookWithCategories)
                            .ThenInclude(x => x.Category);

            return await query.ToListAsync();
        }

        public async Task<List<Book>> GetListByAuthorIdAsync(Guid authorId)
        {
            var dbSet = await GetDbSetAsync();

            var query = dbSet.AsQueryable()
                            .Include(x => x.BookWithAuthors)
                                .ThenInclude(x => x.Author)
                            .AsQueryable();


            query = query.Where(
                            book => book.BookWithAuthors.Any(author => author.AuthorId == authorId)
                        );

            query = query
                        .Include(x => x.BookWithCategories)
                            .ThenInclude(x => x.Category);

            return await query.ToListAsync();
        }

        public async Task<List<Book>> GetListByCategoryIdAsync(Guid categoryId)
        {
            var dbSet = await GetDbSetAsync();

            var query = dbSet.AsQueryable()
                            .Include(x => x.BookWithCategories)
                                .ThenInclude(x => x.Category)
                            .AsQueryable();

            query = query.Where(
                            book => book.BookWithCategories.Any(category => category.CategoryId == categoryId)
                        );

            query = query
                        .Include(x => x.BookWithAuthors)
                            .ThenInclude(x => x.Author);

            return await query.ToListAsync();
        }

        public async Task<List<string>> GetBooksForCalculateTopAsync()
        {
            var dbSet = await GetDbSetAsync();

            var query = dbSet.AsQueryable()
                            .Include(x => x.UserLibraries);

            var books = await query.ToListAsync();

            var booksWithScore = books.Select(book => new
            {
                Book = book,
                Score = book.UserLibraries.Sum(library => library.ReadCount) +
               5 * book.UserLibraries.Count(library => library.IsFavorite)
            });

            // Sort the books based on the score in descending order
            var sortedBooks = booksWithScore.OrderByDescending(book => book.Score);

            // Take the top 2 books
            var topBooks = sortedBooks.Take(2).Select(book => book.Book);

            return topBooks.Select(x => x.Id).ToList();
        }
    }
}
