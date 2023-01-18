using System;
using Volo.Abp.Application.Dtos;

namespace ApiDemo.Books
{
    public class BookWithCategoryDto
    {
        /// <summary>
        /// Category Id.
        /// </summary>
        /// <example>3a089812-bc9a-d45b-59bd-2ca5e566ff64</example>
        public Guid CategoryId { get; set; }
        /// <summary>
        /// Category Name.
        /// </summary>
        /// <example>Economy</example>
        public string CategoryName { get; set; }
    }
}
