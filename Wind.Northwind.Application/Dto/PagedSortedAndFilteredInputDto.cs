namespace Wind.Northwind.Dto
{
    public class PagedSortedAndFilteredInputDto : PagedAndSortedInputDto
    {
        public string Filter { get; set; }
    }
}