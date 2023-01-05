using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace ApiDemo.Users
{
    public class User : FullAuditedAggregateRoot<Guid>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string ImageLink { get; set; }
        public long TotalReadingTime { get; set; }

        private User()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        internal User(
            Guid id,
            string username,
            string password,
            string name,
            string email,
            DateTime birthDate,
            string imageLink
        )
            : base(id)
        {
            Username = username;
            Password = password;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            ImageLink = imageLink;
            TotalReadingTime = 0;
        }
    }
}
