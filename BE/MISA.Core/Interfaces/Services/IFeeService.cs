using MISA.Core.Entities;
using MISA.Core.Resources;
using MISA.Core.Resources.Fee;
using MISA.Core.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Services
{
    /// <summary>
    /// Service cho Fee
    /// </summary>
    /// CreatedBy: NDDONG (13/06/2021)
    public interface IFeeService : IBaseService<FeeResource, CreateFeeResource, UpdateFeeResource, Fee>
    {
        /// <summary>
        /// Xoá nhiều bản ghi
        /// </summary>
        /// <param name="deleteResource">Mảng Id cần xoá</param>
        /// <returns>Kết quả xoá được số bản ghi, lỗi nếu có</returns>
        /// CreatedBy: NDDONG (14/06/2021)
        Task<DeleteResponse<IEnumerable<DetailDelete>>> DeleteManyAsync(DeleteResource deleteResource);

        /// <summary>
        /// Lấy dữ liệu dựa trên phân trang, kết hợp lọc, sắp xếp và tìm kiếm
        /// </summary>
        /// <param name="searchResource">Đối tượng tìm kiếm</param>
        /// <returns>Dữ liệu phân trang được trả về</returns>
        /// CreatedBy: NDDONG (13/06/2021)
        Task<BaseResponse<IEnumerable<FeeResource>>> GetAllPaginationAsync(SearchFeeResource searchResource);
    }
}
