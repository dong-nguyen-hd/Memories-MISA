using MISA.Core.Extensions.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace MISA.Core.Resources.Fee
{
    /// <summary>
    /// Lớp DTO: khoản thu
    /// CreatedBy: NDDONG (12/06/2021)
    /// </summary>
    public class CreateFeeResource
    {
        // Tên khoản thu (NOT NULL)
        [Display(Name = "Fee Name")]
        [Required(ErrorMessage = "Giá trị Tên khoản thu không được bỏ trống")]
        [MaxLength(250)]
        public string FeeName { get; set; }

        // Khoá ngoại nhóm khoản thu
        [Display(Name = "Fee Group Id")]
        public Guid? FeeGroupId { get; set; }

        // Khoá ngoại phạm vi thu
        [Display(Name = "Fee Range Id")]
        [Required(ErrorMessage = "Giá trị Phạm vi thu không được bỏ trống")]
        public Guid FeeRangeId { get; set; }

        // Đơn vị mức thu (NOT NULL)
        [Display(Name = "Unit Fee Id")]
        [Required(ErrorMessage = "Giá trị Đơn vị tính không được bỏ trống")]
        public Guid UnitFeeId { get; set; }

        // Kỳ thu (0: tháng, 1: quý, 2: học kỳ, 3: năm học) (NOT NULL)
        [Display(Name = "Turn Fee")]
        [Required(ErrorMessage = "Giá trị Kỳ thu không được bỏ trống")]
        [TurnFee]
        public byte TurnFee { get; set; }

        // Áp dụng miễn giảm (NOT NULL)
        public bool Discount { get; set; }

        // Mức thu
        [Display(Name = "Amount of Fee")]
        [Range(1, int.MaxValue, ErrorMessage = "Giá trị mức thu phải lớn hơn 0")]
        [Required(ErrorMessage = "Giá trị mức thu không được bỏ trống")]
        public double AmountOfFee { get; set; }

        // Cho phép xuất chứng từ (NOT NULL)
        [Display(Name = "Allow Export License")]
        public bool AllowExportLicense { get; set; }


        // Khoản thu bắt buộc (NOT NULL)
        [Display(Name = "Fee Required")]
        public bool FeeRequired { get; set; }

        // Cho phép hoàn trả (NOT NULL)
        [Display(Name = "Allow Return")]
        public bool AllowReturn { get; set; }

        // Cho phép xuất hoá đơn (NOT NULL)
        [Display(Name = "Allow Export Bill")]
        public bool AllowExportBill { get; set; }

        // Thu nội bộ (NOT NULL)
        [Display(Name = "Fee Private")]
        public bool FeePrivate { get; set; }

        // Phân loại đăng ký (NOT NULL)
        [Display(Name = "Type Registion")]
        public bool TypeRegistion { get; set; }

        // Tính chất
        [Quality]
        public byte? Quality { get; set; }

        // Trạng thái theo dõi (true: ngừng theo dõi, false: đang theo dõi)
        public bool Follow { get; set; }
    }
}
