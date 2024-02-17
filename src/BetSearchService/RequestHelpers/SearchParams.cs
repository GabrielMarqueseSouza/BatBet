namespace BetSearchService.RequestHelpers
{
    public class SearchParams
    {
        public string SearchTerm { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public string FilterBy { get; set; }
        public string OrderBy { get; set; }
        public string UserName { get; set; }
    }
}
