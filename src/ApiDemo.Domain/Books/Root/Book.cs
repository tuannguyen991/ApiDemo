using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace ApiDemo.Books
{
    public class Book : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public int NumberOfPages { get; set; }
        public string EpubLink { get; set; }
        public string ImageLink { get; set; }
        public double AverageRating { get; set; }
        public string Description { get; set; }
        public List<BookWithAuthor> Authors { get; set; }
        public List<BookWithCategory> Categories { get; set; }

        private Book()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        internal Book(
            Guid id,
            string name,
            int numberOfPages,
            string epubLink,
            string imageLink,
            string description
        )
            : base(id)
        {
            Name = name;
            NumberOfPages = numberOfPages;
            EpubLink = epubLink;
            ImageLink = imageLink;
            AverageRating = 0;
            Description = description;
            Authors = new List<BookWithAuthor>();
            Categories = new List<BookWithCategory>();
        }
    }
}
