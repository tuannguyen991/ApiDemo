using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ApiDemo.Users
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        Task<User> FindByUsernameAsync(string username);

        Task<User> FindAsync(Guid id);

        Task<List<Highlight>> FindHighlightsAsync(Guid userId, Guid bookId);

        Task<List<UserLibrary>> GetReadingBooksAsync(Guid id);

        Task<List<UserLibrary>> GetFavoriteBooksAsync(Guid id);
    }
}
