using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace Wind.Northwind.Dto
{
    public class PagedInputDto : IPagedResultRequest
    {
        [Range(1, 1000)]
        public int MaxResultCount { get; set; }

        [Range(0, int.MaxValue)]
        public int SkipCount { get; set; }

        public PagedInputDto()
        {
            MaxResultCount = 10;
        }
    }
}