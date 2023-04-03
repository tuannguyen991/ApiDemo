using System;
using Volo.Abp.Application.Dtos;

namespace ApiDemo.Users
{
    public class CreateUserReadingPackageDto
    {
        /// <summary>
        /// User Id.
        /// </summary>
        /// <example>3a0a1ae0-2435-f8bb-888e-0cff306d0d93</example>
        public Guid UserId { get; set; }
        /// <summary>
        /// Reading Package Id.
        /// </summary>
        /// <example>3a0a1ae0-2417-5b03-b8d2-f64f7c958a53</example>
        public Guid ReadingPackageId { get; set; }
        /// <summary>
        /// Start Date
        /// </summary>
        /// <example>2023-04-10T00:00:08.485286+07:00</example>
        public string StartDate { get; set; }
    }
}
