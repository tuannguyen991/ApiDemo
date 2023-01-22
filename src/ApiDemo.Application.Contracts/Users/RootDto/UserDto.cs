using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace ApiDemo.Users
{
    public class UserDto : EntityDto<Guid>
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
        /// <summary>
        /// Avatar.
        /// </summary>
        /// <example>https://www.dropbox.com/s/jseijks3wxb1jmp/avatarTuan.jpg?raw=1</example>
        public string ImageLink { get; set; }
        /// <summary>
        /// Total Reading Time.
        /// </summary>
        /// <example>0</example>
        public long TotalReadingTime { get; set; }
        /// <summary>
        /// Ranking.
        /// </summary>
        /// <example>0</example>
        public Ranking Ranking { get; set; }
        /// <summary>
        /// Current Package.
        /// </summary>
        /// <example></example>
        public UserReadingPackageDto CurrentPackage { get; set; }
        /// <summary>
        /// Current Package.
        /// </summary>
        /// <example></example>
        public List<UserHistoryDto> RecentlyHistories { get; set; }
        /// <summary>
        ///  Total Reading Books.
        /// </summary>
        /// <example>2</example>
        public int TotalReadingBooks { get; set; }
    }
}
