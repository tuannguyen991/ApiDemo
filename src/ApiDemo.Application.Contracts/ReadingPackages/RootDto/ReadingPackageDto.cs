using System;
using Volo.Abp.Application.Dtos;

namespace ApiDemo.ReadingPackages
{
    public class ReadingPackageDto : EntityDto<Guid>
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
        public string Duration { get; set; }
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
        /// <summary>
        /// DiscountPercentage.
        /// </summary>
        /// <example>0</example>
        public int DiscountPercentage { get; set; }
    }
}