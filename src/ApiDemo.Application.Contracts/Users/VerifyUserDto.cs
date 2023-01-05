using System;
using Volo.Abp.Application.Dtos;

namespace ApiDemo.Users
{
    public class VerifyUserDto
    {
        /// <summary>
        /// Username.
        /// </summary>
        /// <example>tuan_nka</example>
        public string Username { get; set; }
        /// <summary>
        /// Password.
        /// </summary>
        /// <example>123456</example>
        public string Password { get; set; }
    }
}
