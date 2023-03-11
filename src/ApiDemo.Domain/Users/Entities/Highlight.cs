using System;
using ApiDemo.ReadingPackages;
using Volo.Abp.Domain.Entities;

namespace ApiDemo.Users
{
    public class Highlight : Entity<Guid>
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public int PageNumber { get; set; }
        public string PageId { get; set; }
        public string Rangy { get; set; }
        public string Uuid { get; set; }
        public string Note { get; set; }
        
        private Highlight()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        internal Highlight(
            Guid id,
            Guid userId,
            Guid bookId,
            string content,
            DateTime date,
            string type,
            int pageNumber,
            string pageId,
            string rangy,
            string uuid,
            string note
        )
            : base(id)
        {
            UserId = userId;
            BookId = bookId;
            Content = content;
            Date = date;
            Type = type;
            PageNumber = pageNumber;
            PageId = pageId;
            Rangy = rangy;
            Uuid = uuid;
            Note = note;
        }
    }
}
