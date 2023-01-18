using System;
using ApiDemo.ReadingPackages;
using Volo.Abp.Domain.Entities;

namespace ApiDemo.Users
{
    public class UserLibrary : Entity<Guid>
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsReading { get; set; }
        public int NumberOfReadPages { get; set; }
        public double Rating { get; set; }
        public DateTime? LastRead { get; set; }

        private UserLibrary()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        internal UserLibrary(
            Guid id,
            Guid userId,
            Guid bookId,
            bool isFavorite,
            bool isReading,
            int numberOfReadPages,
            DateTime? lastRead
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
        }
    }
}
