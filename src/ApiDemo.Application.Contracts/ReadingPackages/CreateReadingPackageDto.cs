using System;
using Volo.Abp.Application.Dtos;

namespace ApiDemo.ReadingPackages
{
    public class CreateReadingPackageDto
    {
        /// <summary>
        /// ReadingPackage Name.
        /// </summary>
        /// <example>VIP</example>
        public string Name { get; set; }
        /// <summary>
        /// Duration.
        /// </summary>
        /// <example>365.00:00:00</example>
        public TimeSpan Duration { get; set; }
        /// <summary>
        /// Description.
        /// </summary>
        /// <example>VIP package using all features with 1 year validity</example>
        public string Description { get; set; }
        /// <summary>
        /// Price of ReadingPackage.
        /// </summary>
        /// <example>20000</example>
        public double Price { get; set; }
        /// <summary>
        /// Currency.
        /// </summary>
        /// <example>2</example>
        public Currency Currency { get; set; }
    }
}