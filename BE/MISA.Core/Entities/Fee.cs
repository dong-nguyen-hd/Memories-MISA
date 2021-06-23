using System;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Lớp khoản thu
    /// CreatedBy: NDDONG (12/06/2021)
    /// </summary>
    public class Fee
    {
        // Khoá chính (NOT NULL)
        public Guid FeeId { get; set; }
        // Tên khoản thu (NOT NULL)
        public string FeeName { get; set; }
        // Khoá ngoại nhóm khoản thu (NOT NULL) do FE
        public Guid? FeeGroupId { get; set; }
        // Khoá ngoại phạm vi thu
        public Guid? FeeRangeId { get; set; }
        // Đơn vị mức thu (NOT NULL)
        public Guid UnitFeeId { get; set; }
        // Kỳ thu (0: tháng, 1: quý, 2: học kỳ, 3: năm học) (NOT NULL)
        public byte TurnFee { get; set; }
        // Áp dụng miễn giảm (NOT NULL)
        public bool Discount { get; set; }
        // Mức thu
        public double AmountOfFee { get; set; }
        // Cho phép xuất chứng từ (NOT NULL)
        public bool AllowExportLicense { get; set; }
        // Khoản thu bắt buộc (NOT NULL)
        public bool FeeRequired { get; set; }
        // Cho phép hoàn trả (NOT NULL)
        public bool AllowReturn { get; set; }
        // Cho phép xuất hoá đơn (NOT NULL)
        public bool AllowExportBill { get; set; }
        // Thu nội bộ (NOT NULL)
        public bool FeePrivate { get; set; }
        // Phân loại đăng ký (NOT NULL)
        public bool TypeRegistion { get; set; }
        // Thời gian tạo dữ liệu
        public DateTime? CreatedDate { get; set; }
        // Người tạo dữ liệu
        public string CreatedBy { get; set; }
        // Thời gian sửa dữ liệu
        public DateTime? ModifiedDate { get; set; }
        // Tính chất
        public byte? Quality { get; set; }
        // Trạng thái theo dõi (true: ngừng theo dõi, false: đang theo dõi)
        public bool Follow { get; set; }
        // Đánh dấu bản ghi không được phép xóa (NOT NULL)
        public bool Important { get; set; }
    }
}
