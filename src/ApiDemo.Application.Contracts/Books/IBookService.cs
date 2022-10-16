using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ApiDemo.Books
{
    public interface IBookService : IApplicationService
    {
        Task<BookDto> GetAsync(Guid id);

        Task<PagedResultDto<BookDto>> GetListAsync(GetBookListDto input);

        Task<BookDto> CreateAsync(CreateBookDto input);

        Task UpdateAsync(Guid id, UpdateBookDto input);

        Task DeleteAsync(Guid id);
    }
}
