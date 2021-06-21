using MISA.Core.Services.Communication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Services
{
    /// <summary>
    /// Interface base viết các chức năng chung cho tất cả service
    /// </summary>
    /// <typeparam name="Response">Đối tượng trả về</typeparam>
    /// <typeparam name="Insert">Đối tượng thêm mới</typeparam>
    /// <typeparam name="Update">Đối tượng cập nhật</typeparam>
    /// <typeparam name="Entity">Entity generic</typeparam>
    /// CreatedBy: NDDONG (13/06/2021)
    public interface IBaseService<Response, Insert, Update, Entity>
    {
        /// <summary>
        /// Thêm mới một bản ghi
        /// </summary>
        /// <param name="entity">Đối tượng thêm mới</param>
        /// <returns>Response object</returns>
        /// CreatedBy: NDDONG (13/06/2021)
        Task<BaseResponse<Response>> InsertAsync(Insert entity);

        /// <summary>
        /// Cập nhật một bản ghi
        /// </summary>
        /// <param name="id">Id của bản ghi</param>
        /// <param name="entity">Đối tượng cập nhật</param>
        /// <returns>Response object</returns>
        /// CreatedBy: NDDONG (13/06/2021)
        Task<BaseResponse<Response>> UpdateAsync(Guid id, Update entity);

        /// <summary>
        /// Lấy một bản ghi theo id
        /// </summary>
        /// <param name="id">Id của bản ghi</param>
        /// <returns>Response object</returns>
        /// CreatedBy: NDDONG (13/06/2021)
        Task<BaseResponse<Response>> GetByIdAsync(Guid id);

        /// <summary>
        /// Lấy ra tất cả đối tượng
        /// </summary>
        /// <returns>Đối tượng trả về</returns>
        /// CreatedBy: NDDONG (13/06/2021)
        Task<BaseResponse<IEnumerable<Response>>> GetAllAsync();

        /// <summary>
        /// Xoá một bản ghi theo id
        /// </summary>
        /// <param name="id">Id của bản ghi</param>
        /// <returns>Response object</returns>
        /// CreatedBy: NDDONG (13/06/2021)
        Task<BaseResponse<Response>> DeleteAsync(Guid id);
    }
}
