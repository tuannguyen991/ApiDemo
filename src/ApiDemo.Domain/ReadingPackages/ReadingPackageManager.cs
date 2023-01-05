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
            string description,
            double price,
            Currency currency
        )
        {
            return Task.FromResult(
                new ReadingPackage(
                    GuidGenerator.Create(),
                    name,
                    duration,
                    description,
                    price,
                    currency
                )
            );
        }
    }
}
