using System;
using Volo.Abp.Application.Dtos;

namespace ApiDemo.Users
{
    public class UserLibraryDto : EntityDto<Guid>
    {
        /// <summary>
        /// User Id.
        /// </summary>
        /// <example>3a089812-bc9a-d45b-59bd-2ca5e566ff64</example>
        public Guid UserId { get; set; }
        /// <summary>
        /// User Id.
        /// </summary>
        /// <example>3a089812-bc9a-d45b-59bd-2ca5e566ff61</example>
        public Guid BookId { get; set; }
        /// <summary>
        /// IsFavorite.
        /// </summary>
        /// <example></example>
        public bool IsFavorite { get; set; }
        /// <summary>
        /// IsReading.
        /// </summary>
        /// <example></example>
        public bool IsReading { get; set; }
        /// <summary>
        /// Number of Read Pages.
        /// </summary>
        /// <example>0</example>
        public int NumberOfReadPages { get; set; }
        /// <summary>
        /// User Rating.
        /// </summary>
        /// <example>0</example>
        public double Rating { get; set; }
    }
}
