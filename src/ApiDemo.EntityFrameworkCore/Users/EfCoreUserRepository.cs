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
        : EfCoreRepository<ApiDemoDbContext, User, string>,
            IUserRepository
    {
        public EfCoreUserRepository(
            IDbContextProvider<ApiDemoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<User> FindAsync(string id)
        {
            var queryable = await WithDetailsAsync();

            var query = queryable.Where(user => user.Id == id);

            return await AsyncExecuter.FirstOrDefaultAsync(query);
        }

        public async Task<List<Highlight>> FindHighlightsAsync(string userId, string bookId)
        {
            var user = await FindAsync(userId);

            var highlights = user.Highlights;

            var result = highlights.Where(x => x.UserId == userId)
                                    .Where(x => x.BookId == bookId)
                                    .OrderBy(x => x.Date);

            return result.ToList();
        }

        public async Task<List<Highlight>> FindHighlightsByUserIdAsync(string userId)
        {
            var user = await FindAsync(userId);

            var highlights = user.Highlights;

            var result = highlights.Where(x => x.UserId == userId)
                                    .OrderBy(x => x.Date);

            return result.ToList();
        }

        public async Task<List<UserLibrary>> GetReadingBooksAsync(string id)
        {
            var user = await FindAsync(id);
            var userLibraries = user.UserLibraries;

            var result = from book in userLibraries
                         where book.IsReading == true
                         select book;

            return result.ToList();
        }

        public async Task<List<UserLibrary>> GetFavoriteBooksAsync(string id)
        {
            var user = await FindAsync(id);
            var userLibraries = user.UserLibraries;

            var result = from book in userLibraries
                         where book.IsFavorite == true
                         select book;

            return result.ToList();
        }
    }
}
