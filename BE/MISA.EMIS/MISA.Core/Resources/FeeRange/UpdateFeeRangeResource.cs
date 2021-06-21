using System;
using System.ComponentModel.DataAnnotations;

namespace MISA.Core.Resources.FeeRange
{
    /// <summary>
    /// Lớp DTO: phạm vi thu
    /// CreatedBy: NDDONG (12/06/2021)
    /// </summary>
    public class UpdateFeeRangeResource
    {
        // Tên phạm vi thu (NOT NULL)
        [Display(Name = "Fee Range Name")]
        [Required]
        [MaxLength(250)]
        public string FeeRangeName { get; set; }
        // Id cha của phạm vi thu
        [Display(Name = "Parent Id")]
        public Guid ParentId { get; set; }
    }
}
