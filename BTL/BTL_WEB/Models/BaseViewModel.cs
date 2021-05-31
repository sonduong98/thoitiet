namespace Models
{
    public class BaseViewModel
    {
        public bool Error { get; set; }
        public string Message { get; set; }
        // Paging | Sorting
        public string QueryStrings { get; set; }
        public string SortBy { get; set; }
        public string OrderBy { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public string keyWord { get; set; }
    }
}
