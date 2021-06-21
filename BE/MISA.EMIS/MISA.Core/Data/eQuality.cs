using System.ComponentModel;

namespace MISA.Core.Data
{
    /// <summary>
    /// Enum: kỳ thu của lớp khoản thu
    /// CreatedBy: NDDONG (12/06/2021)
    /// </summary>
    public enum eQuality : byte
    {
        [Description("Tính chất 1")]
        One = 0,
        [Description("Tính chất 2")]
        Two,
        [Description("Tính chất 3")]
        Three,
    }
}
