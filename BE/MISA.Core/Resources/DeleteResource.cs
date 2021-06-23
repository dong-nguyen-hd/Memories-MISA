using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MISA.Core.Resources
{
    /// <summary>
    /// Lớp DTO: chứa mảng Id cần xoá
    /// </summary>
    /// CreatedBy: NDDONG (14/06/2021)
    public sealed class DeleteResource
    {
        #region Property
        [MaxLength(100)]
        [Display(Name = "List Delete")]
        public List<Guid> ListDelete { get; set; }
        #endregion
    }

    /// <summary>
    /// Lớp DTO: chứa thông tin kết quả trả về sau khi xoá
    /// </summary>
    /// CreatedBy: NDDONG (14/06/2021)
    public sealed class DetailDelete
    {
        #region Property
        public Guid Id { get; set; }
        public string Error { get; set; }
        #endregion

        #region Constructor
        public DetailDelete(Guid id, string error)
        {
            this.Id = id;
            this.Error = error;
        }
        #endregion
    }
}
