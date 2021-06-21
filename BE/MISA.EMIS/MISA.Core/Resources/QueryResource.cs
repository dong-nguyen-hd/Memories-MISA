namespace MISA.Core.Resources
{
    public class QueryResource
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public QueryResource(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;

            if (Page <= 0)
                Page = 1;

            if (PageSize <= 0 || PageSize > 50)
                PageSize = 10;
        }
    }
}
