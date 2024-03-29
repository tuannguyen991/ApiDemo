using System;
using Volo.Abp.Application.Dtos;

namespace ApiDemo.Users
{
    public class ReminderDto : EntityDto<Guid>
    {
        /// <summary>
        /// Time.
        /// </summary>
        /// <example></example>
        public string Time { get; set; }
        /// <summary>
        /// Is Default.
        /// </summary>
        /// <example></example>
        public bool IsDefault { get; set; }
        /// <summary>
        /// Is Active.
        /// </summary>
        /// <example></example>
        public bool IsActive { get; set; }
    }
}
