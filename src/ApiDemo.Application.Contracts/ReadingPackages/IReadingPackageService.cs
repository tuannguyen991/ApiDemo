using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ApiDemo.ReadingPackages
{
    public interface IReadingPackageService : IApplicationService
    {
        Task<ReadingPackageDto> GetAsync(Guid id);

        Task<ReadingPackageDto> CreateAsync(CreateReadingPackageDto input);
        Task<List<ReadingPackageDto>> GetListAsync(GetReadingPackageListDto input);

        Task UpdateAsync(Guid id, UpdateReadingPackageDto input);

        Task DeleteAsync(Guid id);
    }
}
