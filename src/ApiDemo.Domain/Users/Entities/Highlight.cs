using System;
using ApiDemo.ReadingPackages;
using Volo.Abp.Domain.Entities;

namespace ApiDemo.Users
{
    public class Highlight : Entity<Guid>
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Color { get; set; }
        public string Note { get; set; }
        
        private Highlight()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        internal Highlight(
            Guid id,
            Guid userId,
            Guid bookId,
            DateTime date,
            string location,
            string color,
            string note
        )
            : base(id)
        {
            UserId = userId;
            BookId = bookId;
            Date = date;
            Location = location;
            Color = color;
            Note = note;
        }
    }
}
