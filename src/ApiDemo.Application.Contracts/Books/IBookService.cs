using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ApiDemo.Books
{
    public interface IBookService : IApplicationService
    {
        Task<BookDto> GetAsync(string id);

        Task<List<BookDto>> GetListAsync(GetBookListDto input);

        Task<List<BookDto>> GetListByCategoryIdAsync(Guid categoryId);

        Task<List<BookDto>> GetListByAuthorIdAsync(Guid authorId);

        Task<BookDto> CreateAsync(CreateBookDto input);

        Task UpdateAsync(string id, UpdateBookDto input);

        Task DeleteAsync(string id);
    }
}
