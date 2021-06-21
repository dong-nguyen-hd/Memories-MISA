using MISA.Core.Entities;
using MISA.Core.Resources.Fee;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Repository
{
    public interface IFeeRepository : IBaseRepository<Fee>
    {
        Task<int> TotalRecordsAsync(SearchFeeResource searchResource);
        Task<IEnumerable<Fee>> GetPaginationAsync(SearchFeeResource searchResource);
    }
}
