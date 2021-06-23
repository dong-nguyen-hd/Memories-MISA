using System.ComponentModel.DataAnnotations;

namespace MISA.Core.Resources.UnitFee
{
    /// <summary>
    /// Lớp DTO: đơn vị mức khoản thu
    /// CreatedBy: NDDONG (12/06/2021)
    /// </summary>
    public class UpdateUnitFeeResource
    {
        // Tên đơn vị thu (NOT NULL)
        [Display(Name = "Unit Fee Name")]
        [Required]
        [MaxLength(250)]
        public string UnitFeeName { get; set; }
    }
}
