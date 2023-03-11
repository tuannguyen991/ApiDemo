using System;
using Volo.Abp.Application.Dtos;

namespace ApiDemo.Users
{
    public class GetHighlightDto
    {
        /// <summary>
        /// User Id.
        /// </summary>
        /// <example>3a09e3c3-550e-55d0-3119-d25e4980de56</example>
        public Guid UserId { get; set; }
    }
}
