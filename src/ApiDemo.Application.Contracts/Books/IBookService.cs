using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiDemo.Users;
using Volo.Abp.Application.Services;

namespace ApiDemo.Books
{
    public interface IBookService : IApplicationService
    {
        Task<BookDto> GetAsync(string id);

        Task<List<BookDto>> GetListAsync(GetBookListDto input);

        Task<List<UserBookDto>> GetListByCategoryIdAsync(string userId, Guid categoryId);

        Task<List<UserBookDto>> GetListByAuthorIdAsync(string userId, Guid authorId);

        Task<List<UserBookDto>> GetTopBooksAsync(string userId);

        Task<List<UserBookDto>> GetBookByNameAsync(string userId, GetBookListDto input);

        Task<BookDto> CreateAsync(CreateBookDto input);

        Task UpdateAsync(string id, UpdateBookDto input);

        Task DeleteAsync(string id);
    }
}
