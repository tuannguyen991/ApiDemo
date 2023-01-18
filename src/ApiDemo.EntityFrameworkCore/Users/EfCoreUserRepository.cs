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
            var queryable = await WithDetailsAsync();

            var query = queryable.Where(user => user.Username == username);

            return await AsyncExecuter.FirstOrDefaultAsync(query);
        }

        public async Task<User> FindAsync(Guid id)
        {
            var queryable = await WithDetailsAsync();
            
            var query = queryable.Where(user => user.Id == id);

            return await AsyncExecuter.FirstOrDefaultAsync(query);
        }

        public async Task<List<Highlight>> FindHighlightsAsync(Guid userId, Guid bookId)
        {
            var user = await FindAsync(userId);

            var highlights = user.Highlights;

            var result = from highlight in highlights
                         where highlight.BookId == bookId
                         select highlight;

            return result.ToList();
        }

        public async Task<List<UserLibrary>> GetReadingBooksAsync(Guid id)
        {
            var user = await FindAsync(id);
            var userLibraries = user.UserLibraries;

            var result = from book in userLibraries
                         where book.IsReading == true
                         select book;

            return result.ToList();
        }

        public async Task<List<UserLibrary>> GetFavoriteBooksAsync(Guid id)
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
