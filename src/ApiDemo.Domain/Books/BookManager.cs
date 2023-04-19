using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace ApiDemo.Books
{
    public class BookManager : DomainService
    {
        private readonly IBookRepository _bookRepository;

        public BookManager(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Task<Book> CreateAsync(
            string id,
            string title,
            string subtitle,
            int numberOfPages,
            string epubLink,
            string imageLink,
            string description
        )
        {
            return Task.FromResult(
                new Book(
                    id,
                    title,
                    subtitle,
                    numberOfPages,
                    epubLink,
                    imageLink,
                    description
                )
            );
        }
    }
}
