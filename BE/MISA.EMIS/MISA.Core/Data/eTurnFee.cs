using System.ComponentModel;

namespace MISA.Core.Data
{
    /// <summary>
    /// Enum: tính chất của lớp khoản thu
    /// CreatedBy: NDDONG (12/06/2021)
    /// </summary>
    public enum eTurnFee : byte
    {
        [Description("Tháng")]
        Month = 0,
        [Description("Quý")]
        Quarter,
        [Description("Kỳ học")]
        Semester,
        [Description("Năm học")]
        SchoolYear
    }
}
