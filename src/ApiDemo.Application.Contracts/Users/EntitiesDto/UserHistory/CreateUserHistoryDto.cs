using System;
using Volo.Abp.Application.Dtos;

namespace ApiDemo.Users
{
    public class CreateUserHistoryDto
    {
        /// <summary>
        /// User Id.
        /// </summary>
        /// <example>3a0894a1-a47d-fd52-338c-87a4eec61580</example>
        public Guid UserId { get; set; }
        /// <summary>
        /// Date.
        /// </summary>
        /// <example>2023-01-06T23:32:58.273816</example>
        public DateTime Date { get; set; }
        /// <summary>
        /// Reading Time.
        /// </summary>
        /// <example>00:45:00</example>
        public TimeSpan ReadingTime { get; set; }
    }
}
