using Microsoft.Extensions.Configuration;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;

namespace MISA.Infrastructure.Repository
{
    public class FeeGroupRepository : BaseRepository<FeeGroup>, IFeeGroupRepository
    {
        #region Constructor
        public FeeGroupRepository(IConfiguration configuration) : base(configuration)
        {
        }
        #endregion
    }
}
