using System;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Lớp phạm vi thu
    /// CreatedBy: NDDONG (12/06/2021)
    /// </summary>
    public class FeeRange
    {
        // Khoá chính phạm vi thu (NOT NULL)
        public Guid FeeRangeId { get; set; }
        // Tên phạm vi thu (NOT NULL)
        public string FeeRangeName { get; set; }
        // Id cha của phạm vi thu
        public Guid ParentId { get; set; }
        // Thời gian tạo dữ liệu
        public DateTime? CreatedDate { get; set; }
        // Người tạo dữ liệu
        public string CreatedBy { get; set; }
        // Thời gian chỉnh sửa dữ liệu
        public DateTime? ModifiedDate { get; set; }
    }
}
