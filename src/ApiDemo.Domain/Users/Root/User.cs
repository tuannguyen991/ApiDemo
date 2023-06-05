using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Domain.Entities.Auditing;

namespace ApiDemo.Users
{
    public class User : FullAuditedAggregateRoot<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string ImageLink { get; set; }
        public string UsageTime { get; set; }
        public List<UserReadingPackage> Packages { get; set; }
        public List<UserHistory> Histories { get; set; }
        public List<UserLibrary> UserLibraries { get; set; }
        public List<Highlight> Highlights { get; set; }
        public List<Reminder> Reminders { get; set; }

        private User()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        internal User(
            string id,
            string firstName,
            string lastName,
            string email,
            DateTime birthDate
        )
            : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
            UsageTime = string.Join(";", Enumerable.Repeat(0, 24).ToList());
            Packages = new List<UserReadingPackage>();
            Histories = new List<UserHistory>();
            UserLibraries = new List<UserLibrary>();
            Highlights = new List<Highlight>();
            Reminders = new List<Reminder>();
        }
    }
}