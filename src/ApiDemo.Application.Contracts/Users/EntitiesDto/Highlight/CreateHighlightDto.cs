using System;
using Volo.Abp.Application.Dtos;

namespace ApiDemo.Users
{
    public class CreateHighlightDto
    {
        /// <summary>
        /// User Id.
        /// </summary>
        /// <example>6h38NGTh5lPZMTB0U83Rv0WUE1A2</example>
        public string UserId { get; set; }
        /// <summary>
        /// Book Id.
        /// </summary>
        /// <example>3a09e3c3-5549-740a-4a42-84397e5c0063</example>
        public string BookId { get; set; }
        /// <summary>
        /// Content.
        /// </summary>
        /// <example></example>
        public string Content { get; set; }
        /// <summary>
        /// Date.
        /// </summary>
        /// <example>2023-01-06T23:32:58.273816</example>
        public DateTime Date { get; set; }
        /// <summary>
        /// Type.
        /// </summary>
        /// <example>highlight_underline</example>
        public string Type { get; set; }
        /// <summary>
        /// PageNumber.
        /// </summary>
        /// <example>0</example>
        public int PageNumber { get; set; }
        /// <summary>
        /// PageId.
        /// </summary>
        /// <example>2023-01-06T23:32:58.273816</example>
        public string PageId { get; set; }
        /// <summary>
        /// Rangy.
        /// </summary>
        /// <example></example>
        public string Rangy { get; set; }
        /// <summary>
        /// Uuid.
        /// </summary>
        /// <example>2023-01-06T23:32:58.273816</example>
        public string Uuid { get; set; }
        /// <summary>
        /// Note.
        /// </summary>
        /// <example>This is a note.</example>
        public string Note { get; set; }
    }
}
