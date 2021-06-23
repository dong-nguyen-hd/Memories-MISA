namespace MISA.Core.Resources
{
    /// <summary>
    /// Lớp DTO: sử dụng cho phân trang
    /// </summary>
    /// CreatedBy: NDDONG (14/06/2021)
    public class QueryResource
    {
        #region Property
        public int Page { get; set; }

        public int PageSize { get; set; }
        #endregion

        #region Constructor
        public QueryResource(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;

            if (Page <= 0)
                Page = 1;

            if (PageSize <= 0 || PageSize > 50)
                PageSize = 10;
        }
        #endregion
    }
}
