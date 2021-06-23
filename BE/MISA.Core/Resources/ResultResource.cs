using System.Collections.Generic;

namespace MISA.Core.Resources
{
    /// <summary>
    /// Lớp DTO: dùng thông báo kết quả trả về của request
    /// </summary>
    /// CreatedBy: NDDONG (14/06/2021)
    public class ResultResource
    {
        #region Property
        public bool Success { get; private set; }
        public List<string> Message { get; private set; }
        #endregion

        #region Constructor
        public ResultResource(List<string> messages, bool flag = false)
        {
            this.Message = messages ?? new List<string>();
            this.Success = flag;
        }

        public ResultResource(string message, bool flag = false)
        {
            this.Message = new List<string>();
            this.Success = flag;
            if (!string.IsNullOrWhiteSpace(message))
            {
                this.Message.Add(message);
            }
        }
        #endregion
    }
}
