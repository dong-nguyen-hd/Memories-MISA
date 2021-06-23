using MISA.Core.Resources.Fee;
using MISA.Core.Services.Communication;
using System;

namespace MISA.Core.Extensions
{
    /// <summary>
    /// Lớp tĩnh chứa các phương thức liên quan tới phân trang
    /// CreatedBy: NDDONG (12/06/2021)
    /// </summary>
    public static class RelatePagination
    {
        /// <summary>
        /// Extension-method gán giá trị cho response-pagination
        /// </summary>
        /// <typeparam name="T">Kiểu giá trị trả về cho response</typeparam>
        /// <param name="response">Dữ liệu trả về</param>
        /// <param name="pagination">Đối tượng lọc, tìm kiếm</param>
        /// <param name="totalRecords">Tổng số bản ghi</param>
        /// CreatedBy: NDDONG (16/06/2021)
        public static void CreatePaginationResponse<T>(this PaginationResponse<T> response,
            SearchFeeResource pagination,
            int totalRecords)
        {
            // Gán giá trị Query-Resource
            response.Page = pagination.Page;
            response.PageSize = pagination.PageSize;
            // Gán giá trị Total-Pages
            var totalPages = ((double)totalRecords / (double)pagination.PageSize);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
            // Gán giá trị Next-Page
            response.NextPage = (pagination.Page >= 1 && pagination.Page < roundedTotalPages) ? pagination.Page + 1 : null;
            // Gán giá trị Previous-Page
            response.PreviousPage = (pagination.Page - 1 >= 1 && pagination.Page <= roundedTotalPages) ? pagination.Page - 1 : null;
            // Gán giá trị First-Page
            response.FirstPage = 1;
            // Gán giá trị Last-Page
            response.LastPage = roundedTotalPages;
            // Gán giá trị Total-Pages
            response.TotalPages = roundedTotalPages;
            // Gán giá trị Total-Records
            response.TotalRecords = totalRecords;
        }
    }
}
