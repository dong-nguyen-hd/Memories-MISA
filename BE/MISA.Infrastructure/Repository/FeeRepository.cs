using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Resources.Fee;
using MISA.Infrastructure.Extensions;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MISA.Infrastructure.Repository
{
    public class FeeRepository : BaseRepository<Fee>, IFeeRepository
    {
        #region Constructor
        public FeeRepository(IConfiguration configuration) : base(configuration)
        {
        }
        #endregion

        #region Method
        public async Task<IEnumerable<Fee>> GetPaginationAsync(SearchFeeResource searchResource)
        {
            var sqlPaginationQuery = searchResource.FeePaginationQuery();
            
            try
            {
                using (var connection = new MySqlConnection(ConnectionString))
                {
                    var paginationTask = await connection.QueryAsync<Fee>(sqlPaginationQuery.sqlQuery, sqlPaginationQuery.parameters);

                    return paginationTask;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> TotalRecordsAsync(SearchFeeResource searchResource)
        {
            var sqlTotalRecordsQuery = searchResource.FeeTotalRecordsQuery();

            using (var connection = new MySqlConnection(ConnectionString))
            {
                var totalRecordsTask = await connection.ExecuteScalarAsync<int>(sqlTotalRecordsQuery.sqlQuery, sqlTotalRecordsQuery.parameters);

                return totalRecordsTask;
            }
        }
        #endregion
    }
}
