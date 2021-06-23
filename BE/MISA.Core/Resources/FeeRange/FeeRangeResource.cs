using System;
using System.ComponentModel.DataAnnotations;

namespace MISA.Core.Resources.FeeRange
{
    /// <summary>
    /// Lớp DTO: phạm vi thu
    /// CreatedBy: NDDONG (12/06/2021)
    /// </summary>
    public class FeeRangeResource
    {
        // Khoá chính phạm vi thu (NOT NULL)
        [Display(Name = "Fee Range Id")]
        public Guid FeeRangeId { get; set; }
        // Tên phạm vi thu (NOT NULL)
        [Display(Name = "Fee Range Name")]
        public string FeeRangeName { get; set; }
        // Id cha của phạm vi thu
        [Display(Name = "Parent Id")]
        public Guid ParentId { get; set; }
        // Thời gian tạo dữ liệu
        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }
        // Người tạo dữ liệu
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        // Thời gian chỉnh sửa dữ liệu
        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate { get; set; }
    }
}
