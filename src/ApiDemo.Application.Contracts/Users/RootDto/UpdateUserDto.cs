using System;

namespace ApiDemo.Users
{
    public class UpdateUserDto
    {
        /// <summary>
        /// First name.
        /// </summary>
        /// <example>Tuấn</example>
        public string FirstName { get; set; }
        /// <summary>
        /// Last name.
        /// </summary>
        /// <example>Nguyễn Kiều Anh</example>
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
    }
}
