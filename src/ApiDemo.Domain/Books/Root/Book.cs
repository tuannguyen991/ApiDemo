using System.Collections.Generic;
using ApiDemo.Users;
using Volo.Abp.Domain.Entities.Auditing;

namespace ApiDemo.Books
{
    public class Book : FullAuditedAggregateRoot<string>
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public int NumberOfPages { get; set; }
        public string EpubLink { get; set; }
        public string ImageLink { get; set; }
        public double AverageRating { get; set; }
        public string Description { get; set; }
        public List<BookWithAuthor> BookWithAuthors { get; set; }
        public List<BookWithCategory> BookWithCategories { get; set; }
        public List<UserLibrary> UserLibraries { get; set; }

        private Book()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        internal Book(
            string id,
            string title,
            string subtitle,
            int numberOfPages,
            string epubLink,
            string imageLink,
            string description
        )
            : base(id)
        {
            Title = title;
            Subtitle = subtitle;
            NumberOfPages = numberOfPages;
            EpubLink = epubLink;
            ImageLink = imageLink;
            AverageRating = 0;
            Description = description;
            BookWithAuthors = new List<BookWithAuthor>();
            BookWithCategories = new List<BookWithCategory>();
        }
    }
}
