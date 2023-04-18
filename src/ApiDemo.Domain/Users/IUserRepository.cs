using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ApiDemo.Users
{
    public interface IUserRepository : IRepository<User, string>
    {
        Task<User> FindAsync(string id);

        Task<List<Highlight>> FindHighlightsAsync(string userId);

        Task<List<UserLibrary>> GetReadingBooksAsync(string id);

        Task<List<UserLibrary>> GetFavoriteBooksAsync(string id);
    }
}
