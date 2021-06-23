using MISA.Core.Entities;
using MISA.Core.Resources.UnitFee;

namespace MISA.Core.Interfaces.Services
{
    /// <summary>
    /// Service cho UnitFee
    /// </summary>
    /// CreatedBy: NDDONG (13/06/2021)
    public interface IUnitFeeService : IBaseService<UnitFeeResource, CreateUnitFeeResource, UpdateUnitFeeResource, UnitFee>
    {
    }
}
