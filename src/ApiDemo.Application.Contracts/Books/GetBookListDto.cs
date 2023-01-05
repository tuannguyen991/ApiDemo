using Volo.Abp.Application.Dtos;

namespace ApiDemo.Books
{
    public class GetBookListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
