using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        public List<UserReadingPackage> Packages { get; set; }
        public UserReadingPackage CurrentPackage => Packages.Count == 0 ? null : Packages.Last();
        public List<UserHistory> Histories { get; set; }
        public List<UserHistory> RecentlyHistories => Histories.Count == 0 ? new List<UserHistory>() : Histories.TakeLast(30).ToList();
        public List<UserLibrary> UserLibraries { get; set; } // will be removed
        public List<Highlight> Highlights { get; set; } // will be removed

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
            Packages = new List<UserReadingPackage>();
            Histories = new List<UserHistory>();
            UserLibraries = new List<UserLibrary>();
            Highlights = new List<Highlight>();
        }
    }
}