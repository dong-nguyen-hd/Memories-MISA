namespace MISA.Core.Services.Communication
{
    /// <summary>
    /// Lớp Resopnse: trả về dữ liệu từ service
    /// </summary>
    /// <typeparam name="T">Dữ liệu trả về</typeparam>
    /// CreatedBy: NDDONG (14/06/2021)
    public class BaseResponse<T>
    {
        #region Property
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public T Resource { get; private set; }
        #endregion

        #region Constructor
        public BaseResponse(T resource)
        {
            Success = true;
            Message = "Success";
            Resource = resource;
        }

        public BaseResponse(string message)
        {
            Success = false;
            Message = message;
            Resource = default;
        }
        #endregion
    }
}
