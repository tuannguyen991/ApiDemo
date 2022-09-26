using Volo.Abp.Application.Dtos;

namespace ApiDemo.Authors
{
    public class GetAuthorListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
