using MISA.Core.Entities;
using MISA.Core.Resources.FeeRange;

namespace MISA.Core.Interfaces.Services
{
    /// <summary>
    /// Service cho FeeRange
    /// </summary>
    /// CreatedBy: NDDONG (13/06/2021)
    public interface IFeeRangeService : IBaseService<FeeRangeResource, CreateFeeRangeResource, UpdateFeeRangeResource, FeeRange>
    {
    }
}
