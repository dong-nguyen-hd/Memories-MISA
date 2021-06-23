using Microsoft.Extensions.Configuration;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;

namespace MISA.Infrastructure.Repository
{
    public class FeeRangeRepository : BaseRepository<FeeRange>, IFeeRangeRepository
    {
        #region Constructor
        public FeeRangeRepository(IConfiguration configuration) : base(configuration)
        {
        }
        #endregion
    }
}
