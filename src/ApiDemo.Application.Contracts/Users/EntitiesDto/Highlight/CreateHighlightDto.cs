using System;
using Volo.Abp.Application.Dtos;

namespace ApiDemo.Users
{
    public class CreateHighlightDto
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
        /// <example>2023-01-06T23:32:58.273816</example>
        public DateTime Date { get; set; }
        /// <summary>
        /// Location.
        /// </summary>
        /// <example></example>
        public string Location { get; set; }
        /// <summary>
        /// Color.
        /// </summary>
        /// <example></example>
        public string Color { get; set; }
        /// <summary>
        /// Note.
        /// </summary>
        /// <example>This is a note.</example>
        public string Note { get; set; }
    }
}
