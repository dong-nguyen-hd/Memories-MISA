using MISA.Core.Entities;
using MISA.Core.Resources.FeeRange;

namespace MISA.Core.Interfaces.Services
{
    public interface IFeeRangeService : IBaseService<FeeRangeResource, CreateFeeRangeResource, UpdateFeeRangeResource, FeeRange>
    {
    }
}
