using System;
using Volo.Abp.Application.Dtos;

namespace ApiDemo.Users
{
    public class HighlightNotificationDto
    {
        /// <summary>
        /// Book Name.
        /// </summary>
        /// <example>Harry Potter</example>
        public string BookName { get; set; }
        /// <summary>
        /// Note.
        /// </summary>
        /// <example>Note</example>
        public string Content { get; set; }
    }
}
