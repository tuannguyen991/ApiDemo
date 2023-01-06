using System;
using Volo.Abp.Application.Dtos;

namespace ApiDemo.Users
{
    public class CreateUserReadingPackageDto
    {
        /// <summary>
        /// User Id.
        /// </summary>
        /// <example>3a0894a1-a47d-fd52-338c-87a4eec61580</example>
        public Guid UserId { get; set; }
        /// <summary>
        /// Reading Package Id.
        /// </summary>
        /// <example>3a0894b5-1750-b3b0-afa4-153cc1ec50bb</example>
        public Guid ReadingPackageId { get; set; }
    }
}
