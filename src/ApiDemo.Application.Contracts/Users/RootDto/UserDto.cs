using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace ApiDemo.Users
{
    public class UserDto : EntityDto<Guid>
    {
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
        /// <summary>
        /// Total Reading Time.
        /// </summary>
        /// <example>0</example>
        public long TotalReadingTime { get; set; }
        /// <summary>
        /// Current Package.
        /// </summary>
        /// <example></example>
        public UserReadingPackageDto CurrentPackage  { get; set; }
        /// <summary>
        /// Current Package.
        /// </summary>
        /// <example></example>
        public List<UserHistoryDto> RecentlyHistories  { get; set; }
        /// <summary>
        ///  Library.
        /// </summary>
        /// <example></example>
        public List<UserLibraryDto> UserLibraries  { get; set; } // will be removed
        /// <summary>
        ///  Highlights.
        /// </summary>
        /// <example></example>
        public List<HighlightDto> Highlights  { get; set; } // will be removed
    }
}
