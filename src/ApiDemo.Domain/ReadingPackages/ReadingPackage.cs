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
        public double Price { get; set; }
        public Currency Currency { get; set; }
        public int DiscountPercentage { get; set; }

        private ReadingPackage()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        internal ReadingPackage(
            Guid id,
            string name,
            TimeSpan duration,
            double price,
            Currency currency,
            int discountPercentage
        )
            : base(id)
        {
            Name = name;
            Duration = duration;
            Price = price;
            Currency = currency;
            DiscountPercentage = discountPercentage;
        }
    }
}
