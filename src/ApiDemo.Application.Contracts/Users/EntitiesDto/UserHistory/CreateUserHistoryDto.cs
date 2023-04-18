using System;
using Volo.Abp.Application.Dtos;

namespace ApiDemo.Users
{
    public class CreateUserHistoryDto
    {
        /// <summary>
        /// User Id.
        /// </summary>
        /// <example>6h38NGTh5lPZMTB0U83Rv0WUE1A2</example>
        public string UserId { get; set; }
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
