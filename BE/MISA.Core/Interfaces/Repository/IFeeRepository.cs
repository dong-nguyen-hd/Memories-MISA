using MISA.Core.Entities;
using MISA.Core.Resources.Fee;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Repository
{
    /// <summary>
    /// Repository cho Fee
    /// </summary>
    /// CreatedBy: NDDONG (13/06/2021)
    public interface IFeeRepository : IBaseRepository<Fee>
    {
        /// <summary>
        /// Lấy ra tổng số bản ghi 
        /// </summary>
        /// <param name="searchResource">Đối tượng tìm kiếm</param>
        /// <returns>Tổng số bản ghi</returns>
        /// CreatedBy: NDDONG (15/06/2021)
        Task<int> TotalRecordsAsync(SearchFeeResource searchResource);

        /// <summary>
        /// Phân trang kết hợp tìm kiếm, sắp xếp, và lọc
        /// </summary>
        /// <param name="searchResource">Đối tượng tìm kiếm</param>
        /// <returns>Giá trị trả về được phân trang</returns>
        /// CreatedBy: NDDONG (15/06/2021)
        Task<IEnumerable<Fee>> GetPaginationAsync(SearchFeeResource searchResource);
    }
}
