using System;
using ApiDemo.ReadingPackages;
using Volo.Abp.Application.Dtos;

namespace ApiDemo.Users
{
    public class UserReadingPackageDto
    {
        /// <summary>
        /// Reading Package Id.
        /// </summary>
        /// <example>3a0894b5-1750-b3b0-afa4-153cc1ec50bb</example>
        public Guid ReadingPackageId { get; set; }
        /// <summary>
        /// ReadingPackage Name.
        /// </summary>
        /// <example>Basic</example>
        public string Name { get; set; }
        /// <summary>
        /// Duration.
        /// </summary>
        /// <example>365.00:00:00</example>
        public TimeSpan Duration { get; set; }
        /// <summary>
        /// Price of ReadingPackage.
        /// </summary>
        /// <example>125000</example>
        public double Price { get; set; }
        /// /// <summary>
        /// Currency.
        /// </summary>
        /// <example>1</example>
        public Currency Currency { get; set; }
        /// <summary>
        /// DiscountPercentage.
        /// </summary>
        /// <example>0</example>
        public int DiscountPercentage { get; set; }
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
