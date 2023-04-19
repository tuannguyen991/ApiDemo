using System;
using Volo.Abp.Application.Dtos;

namespace ApiDemo.Users
{
    public class HighlightDto : EntityDto<Guid>
    {
        public string UserId { get; set; }
        public string BookId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public int PageNumber { get; set; }
        public string PageId { get; set; }
        public string Rangy { get; set; }
        public string Uuid { get; set; }
        public string Note { get; set; }
    }
}
