using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ApiDemo.ReadingPackages
{
    public interface IReadingPackageRepository : IRepository<ReadingPackage, Guid>
    {
        Task<List<ReadingPackage>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
