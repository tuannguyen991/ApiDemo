using System;
using ApiDemo.ReadingPackages;
using Volo.Abp.Domain.Entities;

namespace ApiDemo.Users
{
    public class UserReadingPackage : Entity<Guid>
    {
        public string UserId { get; set; }
        public Guid ReadingPackageId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        private UserReadingPackage()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        internal UserReadingPackage(
            Guid id,
            string userId,
            Guid readingPackageId,
            DateTime startDate,
            TimeSpan duration
        )
            : base(id)
        {
            UserId = userId;
            ReadingPackageId = readingPackageId;
            StartDate = startDate;
            EndDate = StartDate + duration;
        }
    }
}
