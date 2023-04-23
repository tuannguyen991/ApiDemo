using System;
using Volo.Abp.Application.Dtos;

namespace ApiDemo.Categories
{
    public class CategoryDto : EntityDto<Guid>
    {
        /// <summary>
        /// Category Name.
        /// </summary>
        /// <example>Business</example>
        public string Name { get; set; }
        /// <summary>
        /// Image Link of Category.
        /// </summary>
        /// <example>https://www.kindpng.com/picc/m/240-2409266_family-business-icon-png-transparent-png.png</example>
        public string ImageLink { get; set; }
    }
}
