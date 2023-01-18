using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ApiDemo.Books
{
    public interface IBookService : IApplicationService
    {
        Task<BookDto> GetAsync(Guid id);

        Task<List<BookDto>> GetListAsync(GetBookListDto input);

        Task<List<BookDto>> GetListByCategoryIdAsync(Guid categoryId);

        Task<List<BookDto>> GetListByAuthorIdAsync(Guid authorId);

        Task<BookDto> CreateAsync(CreateBookDto input);

        Task UpdateAsync(Guid id, UpdateBookDto input);

        Task DeleteAsync(Guid id);
    }
}
