using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace ApiDemo.Books
{
    public class Book: FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public BookType BookType { get; set; }
        public List<string> Authors { get; set; }

        public Book()
        {

        }
        public Book(Guid id, string name, BookType bookType, List<string> authors) : base(id)
        {
            Name = name;
            BookType = bookType;
            Authors = authors;
        }
    }
}
