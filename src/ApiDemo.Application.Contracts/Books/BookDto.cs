using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ApiDemo.Books
{
    public class BookDto: EntityDto<Guid>
    {
        /// <summary>
        /// Book Name.
        /// </summary>
        /// <example>The 7 Habits of Highly Effective People</example>
        public string Name { get; set; }
        /// <summary>
        /// Book Type.
        /// </summary>
        /// <example>Undefined</example>
        public BookType BookType { get; set; }
        /// <summary>
        /// List of authors' names.
        /// </summary>
        /// <example>["Stephen R. Covey"]</example>
        public List<string> Authors { get; set; }
    }
}
