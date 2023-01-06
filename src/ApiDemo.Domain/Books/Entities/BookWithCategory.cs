using System;
using ApiDemo.ReadingPackages;
using Volo.Abp.Domain.Entities;

namespace ApiDemo.Books
{
    public class BookWithCategory : Entity<Guid>
    {
        public Guid BookId { get; set; }
        public Guid CategoryId { get; set; }
        
        private BookWithCategory()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        internal BookWithCategory(
            Guid id,
            Guid bookId,
            Guid categoryId
        )
            : base(id)
        {
            BookId = bookId;
            CategoryId = categoryId;
        }
    }
}
