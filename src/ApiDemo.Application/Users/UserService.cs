using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDemo.Authors;
using ApiDemo.Books;
using ApiDemo.Categories;
using ApiDemo.ReadingPackages;
using Volo.Abp;

namespace ApiDemo.Users
{
    [RemoteService(false)]
    public class UserService : ApiDemoAppService, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IReadingPackageRepository _readingPackageRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly UserManager _userManager;

        public UserService(
            IUserRepository userRepository,
            IReadingPackageRepository readingPackageRepository,
            IBookRepository bookRepository,
            IAuthorRepository authorRepository,
            ICategoryRepository categoryRepository,
            UserManager userManager
        )
        {
            _userRepository = userRepository;
            _readingPackageRepository = readingPackageRepository;
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _categoryRepository = categoryRepository;
            _userManager = userManager;
        }

        public async Task<UserDto> CreateAsync(CreateUserDto input)
        {
            var user = await _userManager.CreateAsync(
                input.Id,
                input.FirstName,
                input.LastName,
                input.Email,
                input.BirthDate
            );

            await _userRepository.InsertAsync(user);

            return ObjectMapper.Map<User, UserDto>(user);
        }

        public async Task<UserDto> GetAsync(string id)
        {
            var user = await _userRepository.GetAsync(id);
            return ObjectMapper.Map<User, UserDto>(user);
        }

        public async Task UpdateAsync(string id, UpdateUserDto input)
        {
            var user = await _userRepository.GetAsync(id);

            user.FirstName = input.FirstName;
            user.LastName = input.LastName;
            user.Email = input.Email;
            user.BirthDate = input.BirthDate;

            await _userRepository.UpdateAsync(user);
        }

        public async Task<UserDto> AddPackageAsync(CreateUserReadingPackageDto input)
        {
            var user = await _userRepository.FindAsync(input.UserId);

            var readingPackage = await _readingPackageRepository.GetAsync(input.ReadingPackageId);

            await _userManager.AddPackageAsync(user, readingPackage.Id, readingPackage.Duration);

            await _userRepository.UpdateAsync(user);

            return ObjectMapper.Map<User, UserDto>(user);
        }

        public async Task<UserDto> AddHistoryAsync(CreateUserHistoryDto input)
        {
            var user = await _userRepository.FindAsync(input.UserId);

            var history = user.Histories.Find(x => x.Date.Date == input.Date.Date);

            if (history != null)
            {
                history.ReadingTime += input.ReadingTime;
            }
            else
            {
                await _userManager.AddHistoryAsync(user, input.Date, input.ReadingTime);
            }

            await _userRepository.UpdateAsync(user);

            return ObjectMapper.Map<User, UserDto>(user);
        }

        #region Highlights
        public async Task<List<HighlightDto>> GetHighlightsAsync(GetHighlightDto input)
        {
            var highlights = await _userRepository.FindHighlightsAsync(input.UserId);

            return ObjectMapper.Map<List<Highlight>, List<HighlightDto>>(highlights);
        }

        public async Task<List<HighlightDto>> AddHighlightAsync(CreateHighlightDto input)
        {
            var user = await _userRepository.FindAsync(input.UserId);

            await _userManager.AddHighlightAsync(user, input.BookId, input.Content, input.Date, input.Type, input.PageNumber, input.PageId, input.Rangy, input.Uuid, input.Note);

            await _userRepository.UpdateAsync(user);

            return ObjectMapper.Map<List<Highlight>, List<HighlightDto>>(user.Highlights);
        }

        public async Task DeleteHighlightAsync(DeleteHighlightDto input)
        {
            var user = await _userRepository.FindAsync(input.UserId);

            await _userManager.DeleteHighlightAsync(user, input.Id);

            await _userRepository.UpdateAsync(user);
        }
        #endregion
        #region User Library
        public async Task<List<UserLibraryDto>> GetReadingBooksAsync(string id)
        {
            var readingBooks = await _userRepository.GetReadingBooksAsync(id);
            var result = new List<UserLibraryDto>();
            foreach (var readingBook in readingBooks)
            {
                var book = await _bookRepository.FindAsync(readingBook.BookId);
                result.Add(
                    new UserLibraryDto
                    {
                        UserId = readingBook.UserId,
                        BookId = readingBook.BookId,
                        NumberOfReadPages = readingBook.NumberOfReadPages,
                        LastRead = readingBook.LastRead,
                        LastLocator = readingBook.LastLocator,
                        Href = readingBook.Href,
                        Rating = readingBook.Rating,
                        Title = book.Title,
                        Subtitle = book.Subtitle,
                        NumberOfPages = book.NumberOfPages,
                        EpubLink = book.EpubLink,
                        ImageLink = book.ImageLink,
                        AverageRating = book.AverageRating,
                        Description = book.Description,
                        Authors = ObjectMapper.Map<List<Author>, List<AuthorDto>>(book.BookWithAuthors.Select(author => _authorRepository.GetAsync(author.AuthorId).Result).ToList()),
                        Categories = ObjectMapper.Map<List<Category>, List<CategoryDto>>(book.BookWithCategories.Select(author => _categoryRepository.GetAsync(author.CategoryId).Result).ToList())
                    }
                );
            }
            return result;
        }
        public async Task<List<UserLibraryDto>> GetFavoriteBooksAsync(string id)
        {
            var favoriteBooks = await _userRepository.GetFavoriteBooksAsync(id);
            var result = new List<UserLibraryDto>();
            foreach (var favoriteBook in favoriteBooks)
            {
                var book = await _bookRepository.FindAsync(favoriteBook.BookId);
                result.Add(
                    new UserLibraryDto
                    {
                        UserId = favoriteBook.UserId,
                        BookId = favoriteBook.BookId,
                        NumberOfReadPages = favoriteBook.NumberOfReadPages,
                        LastRead = favoriteBook.LastRead,
                        Href = favoriteBook.Href,
                        LastLocator = favoriteBook.LastLocator,
                        Rating = favoriteBook.Rating,
                        Title = book.Title,
                        Subtitle = book.Subtitle,
                        NumberOfPages = book.NumberOfPages,
                        EpubLink = book.EpubLink,
                        ImageLink = book.ImageLink,
                        AverageRating = book.AverageRating,
                        Description = book.Description,
                        Authors = ObjectMapper.Map<List<Author>, List<AuthorDto>>(book.BookWithAuthors.Select(author => _authorRepository.GetAsync(author.AuthorId).Result).ToList()),
                        Categories = ObjectMapper.Map<List<Category>, List<CategoryDto>>(book.BookWithCategories.Select(author => _categoryRepository.GetAsync(author.CategoryId).Result).ToList())
                    }
                );
            }
            return result;
        }

        public async Task<bool> GetIsFavoriteAsync(string id, string bookId)
        {
            var favoriteBooks = await _userRepository.GetFavoriteBooksAsync(id);
            var result = favoriteBooks.Exists(x => x.BookId == bookId);
            return result;
        }

        public async Task AddReadingBookAsync(CreateUserLibraryDto input)
        {
            var user = await _userRepository.FindAsync(input.UserId);
            var userLibraries = user.UserLibraries;
            var userLibrary = userLibraries.Find(userLibrary => userLibrary.BookId == input.BookId);

            if (userLibrary != null)
            {
                userLibrary.IsReading = true;
                userLibrary.NumberOfReadPages += input.NumberOfReadPages;
                userLibrary.LastRead = DateTime.Now;
                userLibrary.LastLocator = input.LastLocator;
                userLibrary.Href = input.Href;
            }
            else
            {
                await _userManager.AddReadingBookAsync(user, input.BookId, input.NumberOfReadPages, input.LastLocator, input.Href);
            }
            await _userRepository.UpdateAsync(user);
        }

        public async Task AddFavoriteBookAsync(CreateUserLibraryDto input)
        {
            var user = await _userRepository.FindAsync(input.UserId);
            var userLibraries = user.UserLibraries;
            var userLibrary = userLibraries.Find(userLibrary => userLibrary.BookId == input.BookId);

            if (userLibrary != null)
            {
                userLibrary.IsFavorite = true;
            }
            else
            {
                await _userManager.AddFavoriteBookAsync(user, input.BookId);
            }
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteFavoriteBookAsync(string userId, string bookId)
        {
            var user = await _userRepository.FindAsync(userId);
            var userLibraries = user.UserLibraries;

            var userLibrary = userLibraries.Find(userLibrary => userLibrary.BookId == bookId);

            if (userLibrary.IsReading)
            {
                userLibrary.IsFavorite = false;
            }
            else
            {
                userLibraries.RemoveAll(userLibrary => userLibrary.BookId == bookId);
            }
            await _userRepository.UpdateAsync(user);
        }

        public async Task UploadImageAsync(string id, string path)
        {
            var user = await _userRepository.FindAsync(id);

            user.ImageLink = path;

            await _userRepository.UpdateAsync(user);
        }
        #endregion
    }
}
