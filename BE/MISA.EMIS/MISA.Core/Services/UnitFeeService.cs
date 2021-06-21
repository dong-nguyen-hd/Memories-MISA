using AutoMapper;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using MISA.Core.Resources.UnitFee;

namespace MISA.Core.Services
{
    public class UnitFeeService : BaseService<UnitFeeResource, CreateUnitFeeResource, UpdateUnitFeeResource, UnitFee>, IUnitFeeService
    {
        #region Constructor
        public UnitFeeService(IUnitFeeRepository UnitFeeRepository, IMapper mapper) : base(UnitFeeRepository, mapper)
        {
        }
        #endregion
    }
}
