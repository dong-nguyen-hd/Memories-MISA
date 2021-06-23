using System.Collections.Generic;

namespace MISA.Core.Resources
{
    /// <summary>
    /// Lớp chứa thông báo phản hồi 
    /// </summary>
    /// CreatedBy: NDDONG (21/06/2021)
    public class ResponseMessage
    {
        #region Property
        public Dictionary<string, string> Values { get; set; }
        #endregion
    }
}
