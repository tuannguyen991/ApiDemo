using Volo.Abp.Application.Dtos;

namespace ApiDemo.Categories
{
    public class GetCategoryListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
