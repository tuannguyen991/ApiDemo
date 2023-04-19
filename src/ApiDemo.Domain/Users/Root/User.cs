using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public double TotalReadingTime
            => Histories.Sum(userHistory => userHistory.ReadingTime.TotalMinutes);
        public Ranking Ranking
        {
            get
                => (new RankSpecification().ToExpression()).Invoke(TotalReadingTime);
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
            Packages = new List<UserReadingPackage>();
            Histories = new List<UserHistory>();
            UserLibraries = new List<UserLibrary>();
            Highlights = new List<Highlight>();
        }
    }
}