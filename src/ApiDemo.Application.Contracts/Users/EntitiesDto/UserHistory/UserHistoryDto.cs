using System;
using Volo.Abp.Application.Dtos;

namespace ApiDemo.Users
{
    public class UserHistoryDto
    {
        /// <summary>
        /// Date.
        /// </summary>
        /// <example>2023-01-06T23:32:58.273816</example>
        public DateTime Date { get; set; }
        /// <summary>
        /// Reading Time.
        /// </summary>
        /// <example>00:45:00</example>
        public double ReadingTime { get; set; }
    }
}