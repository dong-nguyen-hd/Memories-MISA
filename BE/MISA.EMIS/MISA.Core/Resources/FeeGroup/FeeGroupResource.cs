using System;
using System.ComponentModel.DataAnnotations;

namespace MISA.Core.Resources.FeeGroup
{
    /// <summary>
    /// Lớp DTO: nhóm khoản thu
    /// CreatedBy: NDDONG (12/06/2021)
    /// </summary>
    public class FeeGroupResource
    {
        // Khoá chính (NOT NULL)
        [Display(Name = "Fee Group Id")]
        public Guid FeeGroupId { get; set; }
        // Tên nhóm khoản thu (NOT NULL)
        [Display(Name = "Fee Group Name")]
        public string FeeGroupName { get; set; }
        // Thời gian tạo dữ liệu
        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }
        // Người tạo dữ liệu
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        // Id của nhóm khoản thu cha
        [Display(Name = "Parent Id")]
        public Guid ParentId { get; set; }
        // Thời gian chỉnh sửa dữ liệu
        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate { get; set; }
    }
}
