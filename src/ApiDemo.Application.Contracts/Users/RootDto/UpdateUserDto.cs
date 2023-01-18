using System;

namespace ApiDemo.Users
{
    public class UpdateUserDto
    {
        /// <summary>
        /// Password.
        /// </summary>
        /// <example>123456</example>
        public string Password { get; set; }
        /// <summary>
        /// First name.
        /// </summary>
        /// <example>Anh Tuấn</example>
        public string FirstName { get; set; }
        /// <summary>
        /// Last name.
        /// </summary>
        /// <example>Nguyễn Kiều</example>
        public string LastName { get; set; }
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
