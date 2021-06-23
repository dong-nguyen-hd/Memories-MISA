using MISA.Core.Entities;
using MISA.Core.Resources.FeeGroup;

namespace MISA.Core.Interfaces.Services
{
    /// <summary>
    /// Service cho FeeGroup
    /// </summary>
    /// CreatedBy: NDDONG (13/06/2021)
    public interface IFeeGroupService : IBaseService<FeeGroupResource, CreateFeeGroupResource, UpdateFeeGroupResource, FeeGroup>
    {
    }
}
