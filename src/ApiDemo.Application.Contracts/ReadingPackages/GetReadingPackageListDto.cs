using Volo.Abp.Application.Dtos;

namespace ApiDemo.ReadingPackages
{
    public class GetReadingPackageListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
