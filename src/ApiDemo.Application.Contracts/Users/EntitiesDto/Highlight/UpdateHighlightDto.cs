using System;
using Volo.Abp.Application.Dtos;

namespace ApiDemo.Users
{
    public class UpdateHighlightDto
    {
        /// <summary>
        /// User Id.
        /// </summary>
        /// <example>6h38NGTh5lPZMTB0U83Rv0WUE1A2</example>
        public string UserId { get; set; }
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
        /// Rangy.
        /// </summary>
        /// <example>2494$2497$6$highlight_green$</example>
        public string Rangy { get; set; }
        /// <summary>
        /// Note.
        /// </summary>
        /// <example>This is a note.</example>
        public string Note { get; set; }
    }
}
