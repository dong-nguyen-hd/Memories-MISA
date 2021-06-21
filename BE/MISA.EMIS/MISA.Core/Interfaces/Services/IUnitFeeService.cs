using MISA.Core.Entities;
using MISA.Core.Resources.UnitFee;

namespace MISA.Core.Interfaces.Services
{
    public interface IUnitFeeService : IBaseService<UnitFeeResource, CreateUnitFeeResource, UpdateUnitFeeResource, UnitFee>
    {
    }
}
