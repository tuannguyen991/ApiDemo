using System;
using Volo.Abp.Application.Dtos;

namespace ApiDemo.Users
{
    public class HighlightDto
    {
        public string BookId { get; set; }
        public string Content { get; set; }
        public long Date { get; set; }
        public string Type { get; set; }
        public int PageNumber { get; set; }
        public string PageId { get; set; }
        public string Rangy { get; set; }
        public string Uuid { get; set; }
        public string Note { get; set; }
    }
}
