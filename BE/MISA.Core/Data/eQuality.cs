using System.ComponentModel;

namespace MISA.Core.Data
{
    /// <summary>
    /// Enum: kỳ thu của lớp khoản thu
    /// CreatedBy: NDDONG (12/06/2021)
    /// </summary>
    public enum eQuality : byte
    {
        [Description("Thu theo thoả thuận")]
        One = 0,
        [Description("Thu trả góp")]
        Two,
        [Description("Thu ngẫu nhiên từng đợt")]
        Three,
    }
}
