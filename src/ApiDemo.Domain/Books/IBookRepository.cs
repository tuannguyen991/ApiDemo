using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ApiDemo.Books
{
    public interface IBookRepository : IRepository<Book, string>
    {
        Task<Book> FindByTitleAsync(string title);

        Task<List<Book>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );

        Task<List<Book>> GetItemsAsync();

        Task<List<string>> GetBooksForCalculateTopAsync();

        Task<Book> GetAsync(string id);

        Task<List<Book>> GetListByCategoryIdAsync(Guid categoryId);

        Task<List<Book>> GetListByAuthorIdAsync(Guid authorId);
    }
}