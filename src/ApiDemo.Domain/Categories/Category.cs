using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace ApiDemo.Categories
{
    public class Category : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string ImageLink { get; set; }

        private Category()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        internal Category(
            Guid id,
            string name,
            string imageLink
        )
            : base(id)
        {
            Name = name;
            ImageLink = imageLink;
        }
    }
}
