using System;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Lớp nhóm khoản thu
    /// CreatedBy: NDDONG (12/06/2021)
    /// </summary>
    public class FeeGroup
    {
        // Khoá chính (NOT NULL)
        public Guid FeeGroupId { get; set; }
        // Tên nhóm khoản thu (NOT NULL)
        public string FeeGroupName { get; set; }
        // Thời gian tạo dữ liệu
        public DateTime? CreatedDate { get; set; }
        // Người tạo dữ liệu
        public string CreatedBy { get; set; }
        // Id của nhóm khoản thu cha
        public Guid ParentId { get; set; }
        // Thời gian chỉnh sửa dữ liệu
        public DateTime? ModifiedDate { get; set; }
    }
}
