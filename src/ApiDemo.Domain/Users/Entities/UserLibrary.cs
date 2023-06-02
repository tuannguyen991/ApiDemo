using System;
using Volo.Abp.Domain.Entities;

namespace ApiDemo.Users
{
    public class UserLibrary : Entity<Guid>
    {
        public string UserId { get; set; }
        public string BookId { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsReading { get; set; }
        public int NumberOfReadPages { get; set; }
        public double Rating { get; set; }
        public DateTime? LastRead { get; set; }
        public string LastLocator { get; set; }
        public string Href { get; set; }
        public int ReadCount { get; set; }

        private UserLibrary()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        internal UserLibrary(
            Guid id,
            string userId,
            string bookId,
            bool isFavorite,
            bool isReading,
            int numberOfReadPages,
            DateTime? lastRead,
            string lastLocator,
            string href
        )
            : base(id)
        {
            UserId = userId;
            BookId = bookId;
            IsFavorite = isFavorite;
            IsReading = isReading;
            NumberOfReadPages = numberOfReadPages;
            Rating = 0;
            LastRead = lastRead;
            LastLocator = lastLocator;
            Href = href;
            ReadCount = 0;
        }
    }
}
