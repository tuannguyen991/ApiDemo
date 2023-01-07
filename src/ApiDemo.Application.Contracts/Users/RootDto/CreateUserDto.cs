using System;
using Volo.Abp.Application.Dtos;

namespace ApiDemo.Users
{
    public class CreateUserDto
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
        /// <summary>
        /// Full name.
        /// </summary>
        /// <example>Nguyễn Kiều Anh Tuấn</example>
        public string Name { get; set; }
        /// <summary>
        /// Email.
        /// </summary>
        /// <example>tuan.nguyen991@hcmut.edu.vn</example>
        public string Email { get; set; }
        /// <summary>
        /// Birthday.
        /// </summary>
        /// <example>2001-02-28</example>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Avatar.
        /// </summary>
        /// <example>https://www.dropbox.com/s/jseijks3wxb1jmp/avatarTuan.jpg?raw=1</example>
        public string ImageLink { get; set; }
    }
}
