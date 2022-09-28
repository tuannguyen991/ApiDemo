using System;
using System.ComponentModel.DataAnnotations;

namespace ApiDemo.Authors
{
    public class CreateAuthorDto
    {
        [Required]
        [StringLength(AuthorConsts.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Tên người nhận.
        /// </summary>
        /// <example>Lê Minh T</example>
        public string ShortBio { get; set; }
    }
}
