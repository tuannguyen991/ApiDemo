using ApiDemo.Authors;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace ApiDemo.Books
{
    [RemoteService(false)]
    public class BookService : ApiDemoAppService, IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(
            IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<BookDto> GetAsync(Guid id)
        {
            var book = await _bookRepository.GetAsync(id);
            return ObjectMapper.Map<Book, BookDto>(book);
        }

        public async Task<PagedResultDto<BookDto>> GetListAsync(GetBookListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Book.Name);
            }

            var books = await _bookRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            var totalCount = input.Filter == null
                ? await _bookRepository.CountAsync()
                : await _bookRepository.CountAsync(
                    book => book.Name.Contains(input.Filter));

            return new PagedResultDto<BookDto>(
                totalCount,
                ObjectMapper.Map<List<Book>, List<BookDto>>(books)
            );
        }

        public async Task<BookDto> CreateAsync(CreateBookDto input)
        {
            var book = new Book(GuidGenerator.Create(), input.Name, input.BookType, input.Authors);
            await _bookRepository.InsertAsync(book);
            return ObjectMapper.Map<Book, BookDto>(book);
        }

        public async Task UpdateAsync(Guid id, UpdateBookDto input)
        {
            var book = await _bookRepository.GetAsync(id);

            book.Name = input.Name;
            book.BookType = input.BookType;

            await _bookRepository.UpdateAsync(book);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _bookRepository.DeleteAsync(id);
        }
    }
}
