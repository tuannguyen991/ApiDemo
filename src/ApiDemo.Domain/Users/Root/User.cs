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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string ImageLink { get; set; }
        public long TotalReadingTime
            => Histories.Sum(userHistory => userHistory.ReadingTime.Minutes);
        public Ranking Ranking
        {
            get
            {
                switch (TotalReadingTime)
                {
                    case < 50:
                        return Ranking.Bronze;
                    case < 500:
                        return Ranking.Silver;
                    default:
                        return Ranking.Gold;
                }
            }
        }
        public List<UserReadingPackage> Packages { get; set; }
        public UserReadingPackage CurrentPackage
            => Packages.Count == 0 ? null : Packages.Last();
        public List<UserHistory> Histories { get; set; }
        public List<UserHistory> RecentlyHistories
            => Histories.Where(new RecentlyUserHistorySpecification().ToExpression()).ToList();
        public List<UserLibrary> UserLibraries { get; set; }
        public int TotalReadingBooks
            => UserLibraries.Count(a => a.IsReading);
        public List<Highlight> Highlights { get; set; }

        private User()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        internal User(
            Guid id,
            string username,
            string password,
            string firstName,
            string lastName,
            string email,
            DateTime birthDate,
            string imageLink
        )
            : base(id)
        {
            Username = username;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
            ImageLink = imageLink;
            Packages = new List<UserReadingPackage>();
            Histories = new List<UserHistory>();
            UserLibraries = new List<UserLibrary>();
            Highlights = new List<Highlight>();
        }
    }
}