using System;
using ApiDemo.ReadingPackages;
using Volo.Abp.Domain.Entities;

namespace ApiDemo.Users
{
    public class UserHistory : Entity<Guid>
    {
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan ReadingTime { get; set; }
        
        private UserHistory()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        internal UserHistory(
            Guid id,
            Guid userId,
            DateTime date,
            TimeSpan readingTime
        )
            : base(id)
        {
            UserId = userId;
            Date = date;
            ReadingTime = readingTime;
        }
    }
}
