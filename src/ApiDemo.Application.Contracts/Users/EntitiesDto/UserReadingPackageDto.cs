using System;
using Volo.Abp.Application.Dtos;

namespace ApiDemo.Users
{
    public class UserReadingPackageDto : EntityDto<Guid>
    {
        /// <summary>
        /// Reading Package Id.
        /// </summary>
        /// <example>3a0894b5-1750-b3b0-afa4-153cc1ec50bb</example>
        public Guid ReadingPackageId { get; set; }
        /// <summary>
        /// Start Date 
        /// </summary>
        /// <example>2023-01-05 23:48:40.538</example>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// End Date 
        /// </summary>
        /// <example>2024-01-05 23:48:40.538</example>
        public DateTime EndDate { get; set; }
    }
}
