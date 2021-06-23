namespace MISA.Core.Services.Communication
{
    /// <summary>
    /// Lớp Resopnse: trả về dữ liệu từ service, 
    /// sau khi thực hiện phân trang
    /// </summary>
    /// <typeparam name="T">Dữ liệu trả về</typeparam>
    /// CreatedBy: NDDONG (14/06/2021)
    public class PaginationResponse<T> : BaseResponse<T>
    {
        #region Property
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int? FirstPage { get; set; }
        public int? LastPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public int? NextPage { get; set; }
        public int? PreviousPage { get; set; }

        #endregion

        #region Constructor
        public PaginationResponse(T resource) : base(resource) { }

        public PaginationResponse(string message) : base(message) { }
        #endregion
    }
}
