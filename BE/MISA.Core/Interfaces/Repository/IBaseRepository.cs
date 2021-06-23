using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Repository
{
    /// <summary>
    /// Interface base viết các chức năng chung cho tất cả repository
    /// </summary>
    /// <typeparam name="T">Đối tượng mapping với bản ghi CSDL</typeparam>
    /// CreatedBy: NDDONG (13/06/2021)
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>
        /// Lấy dữ liệu theo Id
        /// </summary>
        /// <param name="entityId">Id của đối tượng</param>
        /// <returns>Đối tượng trả về</returns>
        /// CreatedBy: NDDONG (13/06/2021)
        Task<T> GetByIdAsync(Guid? entityId);

        /// <summary>
        /// Lấy ra tất cả đối tượng
        /// </summary>
        /// <returns>Đối tượng trả về</returns>
        /// CreatedBy: NDDONG (13/06/2021)
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Kiểm tra trùng tên trong database
        /// </summary>
        /// <param name="entityName">Giá trị tên cần kiểm tra</param>
        /// <returns>Boolean: tên có hợp lệ hay không</returns>
        /// CreatedBy: NDDONG (13/06/2021)
        Task<T> ValidateNameAsync(string entityName);

        /// <summary>
        /// Thêm mới một đối tượng
        /// </summary>
        /// <param name="entity">Đối tượng thêm mới</param>
        /// <returns>Đối tượng đã được thêm mới</returns>
        /// CreatedBy: NDDONG (13/06/2021)
        Task<int> InsertAsync(T entity);

        /// <summary>
        /// Cập nhật dữ liệu cho một đối tượng
        /// </summary>
        /// <param name="id">Id của đối tượng</param>
        /// <param name="entity">Đối tượng chỉnh sửa</param>
        /// <returns>Đối tượng đã được cập nhật</returns>
        /// CreatedBy: NDDONG (13/06/2021)
        Task<int> UpdateAsync(T entity);

        /// <summary>
        /// Xoá dữ liệu của một đối tượng theo Id
        /// </summary>
        /// <param name="id">Id của đối tượng cần xóa</param>
        /// <returns>Đối tượng đã được xoá</returns>
        /// CreatedBy: NDDONG (13/06/2021)
        Task<int> DeleteAsync(Guid id);
    }
}
