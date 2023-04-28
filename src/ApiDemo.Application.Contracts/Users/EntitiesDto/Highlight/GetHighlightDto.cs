using System;
using Volo.Abp.Application.Dtos;

namespace ApiDemo.Users
{
    public class GetHighlightDto
    {
        /// <summary>
        /// User Id.
        /// </summary>
        /// <example>6h38NGTh5lPZMTB0U83Rv0WUE1A2</example>
        public string UserId { get; set; }
        /// <summary>
        /// User Id.
        /// </summary>
        /// <example>b848b9fb-65c0-4691-8b34-39bca5e194d1</example>
        public string BookId { get; set; }
    }
}
