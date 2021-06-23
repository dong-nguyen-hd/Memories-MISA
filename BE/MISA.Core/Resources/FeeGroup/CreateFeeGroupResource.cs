using System;
using System.ComponentModel.DataAnnotations;

namespace MISA.Core.Resources.FeeGroup
{
    /// <summary>
    /// Lớp DTO: nhóm khoản thu
    /// CreatedBy: NDDONG (12/06/2021)
    /// </summary>
    public class CreateFeeGroupResource
    {
        // Tên nhóm khoản thu (NOT NULL)
        [Display(Name = "Fee Group Name")]
        [Required]
        [MaxLength(250)]
        public string FeeGroupName { get; set; }
        // Id của nhóm khoản thu cha
        [Display(Name = "Parent Id")]
        public Guid ParentId { get; set; }
    }
}
