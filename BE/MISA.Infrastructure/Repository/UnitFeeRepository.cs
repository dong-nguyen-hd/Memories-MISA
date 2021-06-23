using Microsoft.Extensions.Configuration;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;

namespace MISA.Infrastructure.Repository
{
    public class UnitFeeRepository : BaseRepository<UnitFee>, IUnitFeeRepository
    {
        #region Constructor
        public UnitFeeRepository(IConfiguration configuration) : base(configuration)
        {
        }
        #endregion
    }
}
