using System;
using ApiDemo.Authors;
using ApiDemo.ReadingPackages;
using Volo.Abp.Domain.Entities;

namespace ApiDemo.Books
{
    public class BookWithAuthor : Entity<Guid>
    {
        public Guid BookId { get; set; }
        public Guid AuthorId { get; set; }

        private BookWithAuthor()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        internal BookWithAuthor(
            Guid id,
            Guid bookId,
            Guid authorId
        )
            : base(id)
        {
            BookId = bookId;
            AuthorId = authorId;
        }
    }
}
