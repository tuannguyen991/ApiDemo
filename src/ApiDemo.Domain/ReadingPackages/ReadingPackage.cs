using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace ApiDemo.ReadingPackages
{
    public class ReadingPackage : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Currency Currency { get; set; }

        private ReadingPackage()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        internal ReadingPackage(
            Guid id,
            string name,
            TimeSpan duration,
            string description,
            double price,
            Currency currency
        )
            : base(id)
        {
            Name = name;
            Duration = duration;
            Description = description;
            Price = price;
            Currency = currency;
        }
    }
}
