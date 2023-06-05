using System;
using Volo.Abp.Domain.Entities;

namespace ApiDemo.Users
{
    public class Reminder : Entity<Guid>
    {
        public string UserId { get; set; }
        public bool IsDefault { get; set; }
        public string Time { get; set; }
        
        private Reminder()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        internal Reminder(
            Guid id,
            string userId,
            string time,
            bool isDefault = false
        ): base(id)
        {
            UserId = userId;
            Time = time;
            Time = time;
            IsDefault = isDefault;
        }
    }
}
