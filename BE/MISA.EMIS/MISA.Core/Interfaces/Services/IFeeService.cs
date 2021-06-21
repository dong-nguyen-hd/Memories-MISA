using MISA.Core.Entities;
using MISA.Core.Resources;
using MISA.Core.Resources.Fee;
using MISA.Core.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Services
{
    public interface IFeeService : IBaseService<FeeResource, CreateFeeResource, UpdateFeeResource, Fee>
    {
        Task<DeleteResponse<IEnumerable<DetailDelete>>> DeleteManyAsync(DeleteResource deleteResource);
        Task<BaseResponse<IEnumerable<FeeResource>>> GetAllPaginationAsync(SearchFeeResource searchResource);
    }
}
