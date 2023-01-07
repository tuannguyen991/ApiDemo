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
        private readonly BookManager _bookManager;

        public BookService(
            IBookRepository bookRepository,
            BookManager bookManager)
        {
            _bookRepository = bookRepository;
            _bookManager = bookManager;
        }

        public async Task<BookDto> GetAsync(Guid id)
        {
            var book = await _bookRepository.GetAsync(id);
            return ObjectMapper.Map<Book, BookDto>(book);
        }

        public async Task<List<BookDto>> GetListAsync(GetBookListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Book.Title);
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
                    book => book.Title.Contains(input.Filter));

            return ObjectMapper.Map<List<Book>, List<BookDto>>(books);
        }

        public async Task<BookDto> CreateAsync(CreateBookDto input)
        {
            var book = await _bookManager.CreateAsync(
                input.Title,
                input.Subtitle,
                input.NumberOfPages,
                input.EpubLink,
                input.ImageLink,
                input.Description
            );

            await _bookRepository.InsertAsync(book);

            return ObjectMapper.Map<Book, BookDto>(book);
        }

        public async Task UpdateAsync(Guid id, UpdateBookDto input)
        {
            var book = await _bookRepository.GetAsync(id);

            // if (book.Name != input.Name)
            // {
            //     await _bookManager.ChangeNameAsync(book, input.Name);
            // }

            book.Title = input.Title;

            book.Subtitle = input.Subtitle;

            book.NumberOfPages = input.NumberOfPages;

            book.EpubLink = input.EpubLink;

            book.ImageLink = input.ImageLink;

            book.Description = input.Description;

            await _bookRepository.UpdateAsync(book);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _bookRepository.DeleteAsync(id);
        }
    }
}
