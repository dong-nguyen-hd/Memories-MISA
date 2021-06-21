using MISA.Core.Entities;
using MISA.Core.Resources.FeeGroup;

namespace MISA.Core.Interfaces.Services
{
    public interface IFeeGroupService : IBaseService<FeeGroupResource, CreateFeeGroupResource, UpdateFeeGroupResource, FeeGroup>
    {
    }
}
