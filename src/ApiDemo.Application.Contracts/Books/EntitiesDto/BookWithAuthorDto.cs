using System;
using Volo.Abp.Application.Dtos;

namespace ApiDemo.Books
{
    public class BookWithAuthorDto
    {
        /// <summary>
        /// Author Id.
        /// </summary>
        /// <example>3a089812-bc9a-d45b-59bd-2ca5e566ff64</example>
        public Guid AuthorId { get; set; }
    }
}
