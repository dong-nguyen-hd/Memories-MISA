using MISA.Core.Resources.FeeGroup;
using MISA.Core.Resources.FeeRange;
using MISA.Core.Resources.UnitFee;
using System;
using System.ComponentModel.DataAnnotations;

namespace MISA.Core.Resources.Fee
{
    /// <summary>
    /// Lớp DTO: khoản thu
    /// CreatedBy: NDDONG (12/06/2021)
    /// </summary>
    public class FeeResource
    {
        // Khoá chính (NOT NULL)
        [Display(Name = "Fee Id")]
        public Guid FeeId { get; set; }
        // Tên khoản thu (NOT NULL)
        [Display(Name = "Fee Name")]
        public string FeeName { get; set; }
        // Khoá ngoại nhóm khoản thu
        [Display(Name = "Fee Group")]
        public FeeGroupResource FeeGroup { get; set; } = new FeeGroupResource();
        // Khoá ngoại phạm vi thu
        [Display(Name = "Fee Range")]
        public FeeRangeResource FeeRange { get; set; } = new FeeRangeResource();
        // Đơn vị mức thu (NOT NULL)
        [Display(Name = "Unit Fee")]
        public UnitFeeResource UnitFee { get; set; } = new UnitFeeResource();
        // Kỳ thu (0: tháng, 1: quý, 2: học kỳ, 3: năm học) (NOT NULL)
        [Display(Name = "Turn Fee")]
        public byte TurnFee { get; set; }
        // Áp dụng miễn giảm (NOT NULL)
        public bool Discount { get; set; }
        // Mức thu
        [Display(Name = "Amount of Fee")]
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
        // Thời gian tạo dữ liệu
        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }
        // Người tạo dữ liệu
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        // Thời gian sửa dữ liệu
        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate { get; set; }
        // Tính chất
        public byte? Quality { get; set; }
        // Trạng thái theo dõi (true: ngừng theo dõi, false: đang theo dõi)
        public bool Follow { get; set; }
        // Đánh dấu bản ghi không được phép xóa (NOT NULL)
        public bool Important { get; set; }
    }
}
