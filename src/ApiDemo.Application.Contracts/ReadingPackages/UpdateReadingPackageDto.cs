using System;
using Volo.Abp.Application.Dtos;

namespace ApiDemo.ReadingPackages
{
    public class UpdateReadingPackageDto
    {
        /// <summary>
        /// ReadingPackage Name.
        /// </summary>
        /// <example>Premium</example>
        public string Name { get; set; }
        /// <summary>
        /// Duration.
        /// </summary>
        /// <example>365.00:00:00</example>
        public TimeSpan Duration { get; set; }
        /// <summary>
        /// Description.
        /// </summary>
        /// <example>Premium package using all features with 1 year validity</example>
        public string Description { get; set; }
        /// <summary>
        /// Price of ReadingPackage.
        /// </summary>
        /// <example>125000</example>
        public double Price { get; set; }
        /// <summary>
        /// Currency.
        /// </summary>
        /// <example>1</example>
        public Currency Currency { get; set; }
    }
}