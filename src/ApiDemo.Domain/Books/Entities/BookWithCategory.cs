using System;
using ApiDemo.Categories;
using ApiDemo.ReadingPackages;
using Volo.Abp.Domain.Entities;

namespace ApiDemo.Books
{
    public class BookWithCategory : Entity<Guid>
    {
        public string BookId { get; set; }
        public Guid CategoryId { get; set; }

        private BookWithCategory()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        internal BookWithCategory(
            Guid id,
            string bookId,
            Guid categoryId
        )
            : base(id)
        {
            BookId = bookId;
            CategoryId = categoryId;
        }
    }
}
