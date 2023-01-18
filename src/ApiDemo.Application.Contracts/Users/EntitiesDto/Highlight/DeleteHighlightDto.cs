using System;
using Volo.Abp.Application.Dtos;

namespace ApiDemo.Users
{
    public class DeleteHighlightDto : EntityDto<Guid>
    {
        /// <summary>
        /// User Id.
        /// </summary>
        /// <example>3a089812-bc9a-d45b-59bd-2ca5e566ff64</example>
        public Guid UserId { get; set; }
    }
}
