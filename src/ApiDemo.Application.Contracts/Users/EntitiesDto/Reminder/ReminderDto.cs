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
    }
}
