using System;
using Volo.Abp.Application.Dtos;

namespace ApiDemo.Users
{
    public class DeleteHighlightDto : EntityDto<Guid>
    {
        /// <summary>
        /// User Id.
        /// </summary>
        /// <example>6h38NGTh5lPZMTB0U83Rv0WUE1A2</example>
        public string UserId { get; set; }
    }
}
