using System;

namespace ApiDemo.Users
{
    public class CreateUserDto
    {
        /// <summary>
        /// Id.
        /// </summary>
        /// <example>6h38NGTh5lPZMTB0U83Rv0WUE1A2</example>
        public string Id { get; set; }
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
