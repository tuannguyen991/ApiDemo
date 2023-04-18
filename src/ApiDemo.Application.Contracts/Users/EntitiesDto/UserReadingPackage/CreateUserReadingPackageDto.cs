using System;
using Volo.Abp.Application.Dtos;

namespace ApiDemo.Users
{
    public class CreateUserReadingPackageDto
    {
        /// <summary>
        /// User Id.
        /// </summary>
        /// <example>6h38NGTh5lPZMTB0U83Rv0WUE1A2</example>
        public string UserId { get; set; }
        /// <summary>
        /// Reading Package Id.
        /// </summary>
        /// <example>3a0894b5-1750-b3b0-afa4-153cc1ec50bb</example>
        public Guid ReadingPackageId { get; set; }
    }
}
