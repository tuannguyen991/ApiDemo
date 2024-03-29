using System;
using ApiDemo.Books;
using ApiDemo.ReadingPackages;
using Volo.Abp.Domain.Entities;

namespace ApiDemo.Users
{
    public class Highlight : Entity<Guid>
    {
        public string UserId { get; set; }
        public string BookId { get; set; }
        public string Content { get; set; }
        public long Date { get; set; }
        public string Type { get; set; }
        public int PageNumber { get; set; }
        public string PageId { get; set; }
        public string Rangy { get; set; }
        public string Uuid { get; set; }
        public string Note { get; set; }
        public Book Book { get; set; }
        
        private Highlight()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        internal Highlight(
            string userId,
            string bookId,
            string content,
            long date,
            string type,
            int pageNumber,
            string pageId,
            string rangy,
            string uuid,
            string note
        ): base(new Guid(uuid))
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
