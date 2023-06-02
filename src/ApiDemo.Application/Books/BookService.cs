using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiDemo.Authors;
using ApiDemo.Categories;
using ApiDemo.Users;
using Volo.Abp;
using Volo.Abp.Guids;

namespace ApiDemo.Books
{
    [RemoteService(false)]
    public class BookService : ApiDemoAppService, IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository;
        private readonly BookManager _bookManager;
        private readonly IGuidGenerator _guidGenerator;

        public BookService(
            IBookRepository bookRepository,
            IAuthorRepository authorRepository,
            IUserRepository userRepository,
            ICategoryRepository categoryRepository,
            BookManager bookManager,
            IGuidGenerator guidGenerator
        )
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
            _bookManager = bookManager;
            _guidGenerator = guidGenerator;
        }

        #region CRUD basic
        public async Task<BookDto> GetAsync(string id)
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

            return ObjectMapper.Map<List<Book>, List<BookDto>>(books);
        }

        public async Task<BookDto> CreateAsync(CreateBookDto input)
        {
            var book = await _bookManager.CreateAsync(
                _guidGenerator.Create().ToString(),
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

        public async Task UpdateAsync(string id, UpdateBookDto input)
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

        public async Task DeleteAsync(string id)
        {
            await _bookRepository.DeleteAsync(id);
        }
        #endregion

        #region User relevant
        public async Task<List<UserBookDto>> GetListByCategoryIdAsync(string userId, Guid categoryId)
        {
            var books = await _bookRepository.GetListByCategoryIdAsync(categoryId);

            var bookDtos = ObjectMapper.Map<List<Book>, List<UserBookDto>>(books);

            if (userId == "null")
                return bookDtos;

            var userLibraries = (await _userRepository.GetAsync(userId)).UserLibraries;

            if (userLibraries.Count == 0)
                return bookDtos;

            foreach (var bookDto in bookDtos)
            {
                var userLibrary = userLibraries.Find(x => x.BookId == bookDto.Id);
                if (userLibrary != null)
                    bookDto.UserLibrary = ObjectMapper.Map<UserLibrary, UserLibraryDto>(userLibrary);
            }

            return bookDtos;
        }

        public async Task<List<UserBookDto>> GetListByAuthorIdAsync(string userId, Guid authorId)
        {
            var books = await _bookRepository.GetListByAuthorIdAsync(authorId);

            var bookDtos = ObjectMapper.Map<List<Book>, List<UserBookDto>>(books);

            if (userId == "null")
                return bookDtos;

            var userLibraries = (await _userRepository.GetAsync(userId)).UserLibraries;

            if (userLibraries.Count == 0)
                return bookDtos;

            foreach (var bookDto in bookDtos)
            {
                var userLibrary = userLibraries.Find(x => x.BookId == bookDto.Id);
                if (userLibrary != null)
                    bookDto.UserLibrary = ObjectMapper.Map<UserLibrary, UserLibraryDto>(userLibrary);
            }

            return bookDtos;
        }

        public async Task<List<UserBookDto>> GetTopBooksAsync(string userId)
        {
            List<string> idsString = await _bookRepository.GetBooksForCalculateTopAsync();

            var topBooksDto = new List<UserBookDto>();

            foreach (var idString in idsString)
            {
                var bookDto = ObjectMapper.Map<Book, UserBookDto>(await _bookRepository.GetAsync(idString));
                topBooksDto.Add(bookDto);
            }

            if (userId == "null")
                return topBooksDto;

            var userLibraries = (await _userRepository.GetAsync(userId)).UserLibraries;

            if (userLibraries.Count == 0)
                return topBooksDto;

            foreach (var bookDto in topBooksDto)
            {
                var userLibrary = userLibraries.Find(x => x.BookId == bookDto.Id);
                if (userLibrary != null)
                    bookDto.UserLibrary = ObjectMapper.Map<UserLibrary, UserLibraryDto>(userLibrary);
            }

            return topBooksDto;
        }

        public async Task<List<UserBookDto>> GetBookByNameAsync(string userId, GetBookListDto input)
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

            var booksDto = ObjectMapper.Map<List<Book>, List<UserBookDto>>(books);

            if (userId == "null")
                return booksDto;

            var userLibraries = (await _userRepository.GetAsync(userId)).UserLibraries;

            if (userLibraries.Count == 0)
                return booksDto;

            foreach (var bookDto in booksDto)
            {
                var userLibrary = userLibraries.Find(x => x.BookId == bookDto.Id);
                if (userLibrary != null)
                    bookDto.UserLibrary = ObjectMapper.Map<UserLibrary, UserLibraryDto>(userLibrary);
            }

            return booksDto;
        }
        #endregion
    }
}
