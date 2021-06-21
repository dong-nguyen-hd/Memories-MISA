namespace MISA.Core.Services.Communication
{
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
