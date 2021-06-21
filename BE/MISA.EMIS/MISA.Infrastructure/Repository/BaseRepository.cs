using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Core.Interfaces.Repository;
using MISA.Infrastructure.Extensions;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MISA.Infrastructure.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        #region Property
        protected readonly string TableName;
        protected string ConnectionString { get; private set; }
        #endregion

        #region Constructor
        public BaseRepository(IConfiguration configuration)
        {
            this.TableName = typeof(T).Name;
            this.ConnectionString = configuration["ConnectionStrings:MySqlConnection"];
        }
        #endregion

        #region Method
        public virtual async Task<int> DeleteAsync(Guid entityId)
        {
            var tempData = entityId.DeleteQuery(TableName);

            try
            {
                using (var connection = new MySqlConnection(ConnectionString))
                {
                    var rowsAffected = await connection.ExecuteAsync(tempData.sqlQuery, tempData.parameters);
                    return rowsAffected;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<T> ValidateNameAsync(string entityName)
        {
            var tempData = TableName.ValidateNameQuery(entityName);

            try
            {
                using (var connection = new MySqlConnection(ConnectionString))
                {
                    var dataResponse = await connection.QueryFirstOrDefaultAsync<T>(tempData.sqlQuery, tempData.parameters);

                    return dataResponse;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<T> GetByIdAsync(Guid? entityId)
        {
            if (entityId is null)
                return new T();

            var tempData = entityId.GetByIdQuery(TableName);

            try
            {
                using (var connection = new MySqlConnection(ConnectionString))
                {
                    var dataResponse = await connection.QuerySingleOrDefaultAsync<T>(tempData.sqlQuery, tempData.parameters);

                    return dataResponse;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            var sqlQuery = TableName.GetAllQuery();

            try
            {
                using (var connection = new MySqlConnection(ConnectionString))
                {
                    var dataResponse = await connection.QueryAsync<T>(sqlQuery);

                    return dataResponse;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<int> InsertAsync(T entity)
        {
            var tempData = entity.InsertQuery(TableName);

            try
            {
                using (var connection = new MySqlConnection(ConnectionString))
                {
                    var rowsAffected = await connection.ExecuteAsync(tempData.sqlQuery, tempData.parameters);

                    return rowsAffected;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<int> UpdateAsync(T entity)
        {
            var tempData = entity.UpdateQuery(TableName);

            try
            {
                using (var connection = new MySqlConnection(ConnectionString))
                {
                    var rowsAffected = await connection.ExecuteAsync(tempData.sqlQuery, tempData.parameters);

                    return rowsAffected;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
