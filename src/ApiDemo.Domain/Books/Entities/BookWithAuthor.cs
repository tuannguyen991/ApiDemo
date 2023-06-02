using System;
using ApiDemo.Authors;
using Volo.Abp.Domain.Entities;

namespace ApiDemo.Books
{
    public class BookWithAuthor : Entity<Guid>
    {
        public string BookId { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }

        private BookWithAuthor()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        internal BookWithAuthor(
            Guid id,
            string bookId,
            Guid authorId
        )
            : base(id)
        {
            BookId = bookId;
            AuthorId = authorId;
        }
    }
}
