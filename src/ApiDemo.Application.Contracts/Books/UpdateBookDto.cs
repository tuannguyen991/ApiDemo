using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ApiDemo.Books
{
    public class UpdateBookDto: EntityDto<Guid>
    {
        /// <summary>
        /// Book Name.
        /// </summary>
        /// <example>The 7 Habits of Highly Effective People</example>
        [Required]
        [StringLength(BookConsts.MaxNameLength)]
        public string Name { get; set; }
        /// <summary>
        /// Book Type.
        /// </summary>
        /// <example>Undefined</example>
        [Required] 
        public BookType BookType { get; set; }
        /// <summary>
        /// List of authors' names.
        /// </summary>
        /// <example>["Stephen R. Covey"]</example>
        public List<string> Authors { get; set; }
    }
}
