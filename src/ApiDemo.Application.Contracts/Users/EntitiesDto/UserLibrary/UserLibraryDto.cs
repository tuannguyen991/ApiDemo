using System;

namespace ApiDemo.Users
{
    public class UserLibraryDto
    {
        /// <summary>
        /// Book Id.
        /// </summary>
        /// <example></example>
        public string BookId { get; set; }
        /// <summary>
        /// Is Favorite Book.
        /// </summary>
        /// <example></example>
        public bool IsFavorite { get; set; }
        /// <summary>
        /// Is Reading Book.
        /// </summary>
        /// <example></example>
        public bool IsReading { get; set; }
        /// <summary>
        /// Number of Read Pages.
        /// </summary>
        /// <example>0</example>
        public int NumberOfReadPages { get; set; }
        /// <summary>
        /// Last Read.
        /// </summary>
        /// <example></example>
        public DateTime? LastRead { get; set; }
        /// <summary>
        /// Last Read.
        /// </summary>
        /// <example></example>
        public string LastLocator { get; set; }
        /// <summary>
        /// Href.
        /// </summary>
        /// <example></example>
        public string Href { get; set; }
        /// <summary>
        /// User Rating.
        /// </summary>
        /// <example>0</example>
        public double Rating { get; set; }
    }
}
