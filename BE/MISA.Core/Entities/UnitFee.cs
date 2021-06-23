using System;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Lớp đơn vị mức khoản thu
    /// CreatedBy: NDDONG (12/06/2021)
    /// </summary>
    public class UnitFee
    {
        // Khoá chính đơn vị thu (NOT NULL)
        public Guid UnitFeeId { get; set; }
        // Tên đơn vị thu (NOT NULL)
        public string UnitFeeName { get; set; }
        // Thời gian tạo dữ liệu
        public DateTime? CreatedDate { get; set; }
        // Người tạo dữ liệu
        public string CreatedBy { get; set; }
        // Thời gian thay đổi dữ liệu
        public DateTime? ModifiedDate { get; set; }
    }
}
