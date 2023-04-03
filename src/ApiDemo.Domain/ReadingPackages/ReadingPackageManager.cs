using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace ApiDemo.ReadingPackages
{
    public class ReadingPackageManager : DomainService
    {
        private readonly IReadingPackageRepository _readingPackageRepository;

        public ReadingPackageManager(IReadingPackageRepository readingPackageRepository)
        {
            _readingPackageRepository = readingPackageRepository;
        }

        public Task<ReadingPackage> CreateAsync(
            string name,
            TimeSpan duration,
            double price,
            Currency currency,
            int discountPercentage
        )
        {
            return Task.FromResult(
                new ReadingPackage(
                    GuidGenerator.Create(),
                    name,
                    duration.ToString(),
                    price,
                    currency,
                    discountPercentage
                )
            );
        }
    }
}
