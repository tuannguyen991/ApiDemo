using System;
using System.Collections.Generic;
using ApiDemo.Books;
using Volo.Abp.Application.Dtos;

namespace ApiDemo.Users
{
    public class CreateUserLibraryDto
    {
        /// <summary>
        /// User Id.
        /// </summary>
        /// <example>3a089812-bc9a-d45b-59bd-2ca5e566ff64</example>
        public Guid UserId { get; set; }
        /// <summary>
        /// User Id.
        /// </summary>
        /// <example>3a089812-bc9a-d45b-59bd-2ca5e566ff61</example>
        public Guid BookId { get; set; }
        /// <summary>
        /// Number of Read Pages.
        /// </summary>
        /// <example>0</example>
        public int NumberOfReadPages { get; set; }
    }
}
