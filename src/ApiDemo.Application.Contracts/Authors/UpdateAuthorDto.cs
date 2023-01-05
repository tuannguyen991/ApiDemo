using System;
using System.ComponentModel.DataAnnotations;

namespace ApiDemo.Authors
{
    public class UpdateAuthorDto
    {
        /// <summary>
        /// Author Name.
        /// </summary>
        /// <example>J.K. Rowling</example>
        [Required]
        [StringLength(AuthorConsts.MaxNameLength)]
        public string Name { get; set; }
        /// <summary>
        /// Birthday.
        /// </summary>
        /// <example>1965-07-31</example>
        [Required]
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Short biography of Author.
        /// </summary>
        /// <example>Joanne Rowling was born on 31st July 1965 at Yate General Hospital near Bristol</example>
        public string ShortBio { get; set; }
        /// <summary>
        /// Image Link of Author.
        /// </summary>
        /// <example>https://www.shutterstock.com/image-photo/jk-rowling-arriving-world-premiere-600w-89959006.jpg</example>
        public string ImageLink { get; set; }
    }
}
