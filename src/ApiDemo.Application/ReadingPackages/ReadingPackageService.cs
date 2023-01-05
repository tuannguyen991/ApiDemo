using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace ApiDemo.ReadingPackages
{
    [RemoteService(false)]
    public class ReadingPackageService : ApiDemoAppService, IReadingPackageService
    {
        private readonly IReadingPackageRepository _readingPackageRepository;
        private readonly ReadingPackageManager _readingPackageManager;

        public ReadingPackageService(
            IReadingPackageRepository readingPackageRepository,
            ReadingPackageManager readingPackageManager)
        {
            _readingPackageRepository = readingPackageRepository;
            _readingPackageManager = readingPackageManager;
        }

        public async Task<ReadingPackageDto> GetAsync(Guid id)
        {
            var readingPackage = await _readingPackageRepository.GetAsync(id);
            return ObjectMapper.Map<ReadingPackage, ReadingPackageDto>(readingPackage);
        }

        public async Task<List<ReadingPackageDto>> GetListAsync(GetReadingPackageListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(ReadingPackage.Name);
            }

            var readingPackages = await _readingPackageRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            var totalCount = input.Filter == null
                ? await _readingPackageRepository.CountAsync()
                : await _readingPackageRepository.CountAsync(
                    readingPackage => readingPackage.Name.Contains(input.Filter));

            return ObjectMapper.Map<List<ReadingPackage>, List<ReadingPackageDto>>(readingPackages);
        }

        public async Task<ReadingPackageDto> CreateAsync(CreateReadingPackageDto input)
        {
            var readingPackage = await _readingPackageManager.CreateAsync(
                input.Name,
                input.Duration,
                input.Description,
                input.Price,
                input.Currency
            );

            await _readingPackageRepository.InsertAsync(readingPackage);

            return ObjectMapper.Map<ReadingPackage, ReadingPackageDto>(readingPackage);
        }

        public async Task UpdateAsync(Guid id, UpdateReadingPackageDto input)
        {
            var readingPackage = await _readingPackageRepository.GetAsync(id);

            // if (readingPackage.Name != input.Name)
            // {
            //     await _readingPackageManager.ChangeNameAsync(readingPackage, input.Name);
            // }

            readingPackage.Name = input.Name;
            readingPackage.Duration = input.Duration;
            readingPackage.Description = input.Description;
            readingPackage.Price = input.Price;
            readingPackage.Currency = input.Currency;

            await _readingPackageRepository.UpdateAsync(readingPackage);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _readingPackageRepository.DeleteAsync(id);
        }
    }
}
