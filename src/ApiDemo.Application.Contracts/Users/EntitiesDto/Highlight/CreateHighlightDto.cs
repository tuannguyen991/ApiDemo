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
        /// <example>Test</example>
        public string Content { get; set; }
        /// <summary>
        /// Date.
        /// </summary>
        /// <example>1682388420000</example>
        public long Date { get; set; }
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
        /// <example>b848b9fb-65c0-4691-8b34-39bca5e194d1$/text/part0005.html</example>
        public string PageId { get; set; }
        /// <summary>
        /// Rangy.
        /// </summary>
        /// <example>2494$2497$6$highlight_green$</example>
        public string Rangy { get; set; }
        /// <summary>
        /// Uuid.
        /// </summary>
        /// <example>74e1f495-7ddd-4142-8794-65bb2aa73aec</example>
        public string Uuid { get; set; }
        /// <summary>
        /// Note.
        /// </summary>
        /// <example>This is a note.</example>
        public string Note { get; set; }
    }
}
