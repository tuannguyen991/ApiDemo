using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDemo.Authors;
using ApiDemo.Categories;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace ApiDemo.Books
{
    [RemoteService(false)]
    public class BookService : ApiDemoAppService, IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly BookManager _bookManager;

        public BookService(
            IBookRepository bookRepository,
            IAuthorRepository authorRepository,
            ICategoryRepository categoryRepository,
            BookManager bookManager
        )
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _categoryRepository = categoryRepository;
            _bookManager = bookManager;
        }

        public async Task<BookDto> GetAsync(Guid id)
        {
            var book = await _bookRepository.GetAsync(id);

            book.Authors = book.BookWithAuthors.Select(author => _authorRepository.GetAsync(author.AuthorId).Result).ToList();
            book.Categories = book.BookWithCategories.Select(author => _categoryRepository.GetAsync(author.CategoryId).Result).ToList();

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

            foreach (var book in books)
            {
                book.Authors = book.BookWithAuthors.Select(author => _authorRepository.GetAsync(author.AuthorId).Result).ToList();
                book.Categories = book.BookWithCategories.Select(author => _categoryRepository.GetAsync(author.CategoryId).Result).ToList();
            }

            return ObjectMapper.Map<List<Book>, List<BookDto>>(books);
        }

        public async Task<List<BookDto>> GetListByCategoryIdAsync(Guid categoryId)
        {
            var books = await _bookRepository.GetListByCategoryIdAsync(categoryId);

            foreach (var book in books)
            {
                book.Authors = book.BookWithAuthors.Select(author => _authorRepository.GetAsync(author.AuthorId).Result).ToList();
                book.Categories = book.BookWithCategories.Select(author => _categoryRepository.GetAsync(author.CategoryId).Result).ToList();
            }

            return ObjectMapper.Map<List<Book>, List<BookDto>>(books);
        }

        public async Task<List<BookDto>> GetListByAuthorIdAsync(Guid authorId)
        {
            var books = await _bookRepository.GetListByAuthorIdAsync(authorId);

            foreach (var book in books)
            {
                book.Authors = book.BookWithAuthors.Select(author => _authorRepository.GetAsync(author.AuthorId).Result).ToList();
                book.Categories = book.BookWithCategories.Select(author => _categoryRepository.GetAsync(author.CategoryId).Result).ToList();
            }

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

            book.Authors = book.BookWithAuthors.Select(author => _authorRepository.GetAsync(author.AuthorId).Result).ToList();
            book.Categories = book.BookWithCategories.Select(author => _categoryRepository.GetAsync(author.CategoryId).Result).ToList();

            return ObjectMapper.Map<Book, BookDto>(book);
        }

        public async Task UpdateAsync(Guid id, UpdateBookDto input)
        {
            var book = await _bookRepository.GetAsync(id);

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
