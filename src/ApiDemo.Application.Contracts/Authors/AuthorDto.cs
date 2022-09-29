using System;
using Volo.Abp.Application.Dtos;

namespace ApiDemo.Authors
{
    public class AuthorDto : EntityDto<Guid>
    {
        /// <summary>
        /// Author Name.
        /// </summary>
        /// <example>J.K. Rowling</example>
        public string Name { get; set; }
        /// <summary>
        /// Birthday.
        /// </summary>
        /// <example>1965-07-31</example>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Short biography of Author.
        /// </summary>
        /// <example>Joanne Rowling was born on 31st July 1965 at Yate General Hospital near Bristol</example>
        public string ShortBio { get; set; }
    }
}
