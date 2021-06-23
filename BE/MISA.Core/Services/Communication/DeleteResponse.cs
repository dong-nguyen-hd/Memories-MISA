namespace MISA.Core.Services.Communication
{
    /// <summary>
    /// Lớp Resopnse: trả về dữ liệu từ service, 
    /// sau khi thực hiện xoá dữ liệu
    /// </summary>
    /// <typeparam name="T">Dữ liệu trả về</typeparam>
    /// CreatedBy: NDDONG (14/06/2021)
    public class DeleteResponse<T> : BaseResponse<T>
    {
        #region Property
        public int TotalRequest { get; set; }
        public int TotalDeleted { get; set; }
        #endregion

        #region Constructor
        public DeleteResponse(int totalRequest, int TotalDeleted, T resource) : base(resource)
        {
            this.TotalRequest = totalRequest;
            this.TotalDeleted = TotalDeleted;
        }

        public DeleteResponse(string message) : base(message)
        {
        }
        #endregion
    }
}
