using System;
using System.ComponentModel.DataAnnotations;

namespace MISA.Core.Resources.UnitFee
{
    /// <summary>
    /// Lớp DTO: đơn vị mức khoản thu
    /// CreatedBy: NDDONG (12/06/2021)
    /// </summary>
    public class UnitFeeResource
    {
        // Khoá chính đơn vị thu (NOT NULL)
        [Display(Name = "Unit Fee Id")]
        public Guid UnitFeeId { get; set; }
        // Tên đơn vị thu (NOT NULL)
        [Display(Name = "Unit Fee Name")]
        public string UnitFeeName { get; set; }
        // Thời gian tạo dữ liệu
        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }
        // Người tạo dữ liệu
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        // Thời gian thay đổi dữ liệu
        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate { get; set; }
    }
}
