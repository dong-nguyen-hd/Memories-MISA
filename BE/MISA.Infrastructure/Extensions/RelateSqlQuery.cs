using Dapper;
using MISA.Core.Resources.Fee;
using System;
using System.Text;

namespace MISA.Infrastructure.Extensions
{
    /// <summary>
    /// Lớp tĩnh: tạo câu sql query, cùng parameter tương ứng
    /// </summary>
    /// CreatedBy: NDDONG (14/06/2021)
    public static class RelateSqlQuery
    {
        public static (string sqlQuery, DynamicParameters parameters) InsertQuery<T>(this T entity, string tableName) where T : class
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            StringBuilder partOne = new StringBuilder();
            StringBuilder partTwo = new StringBuilder();

            var properties = entity.GetType().GetProperties();
            int countProperties = properties.Length;

            for (int i = 0; i < countProperties; i++)
            {
                string propertyName = properties?[i].Name;
                var propertyValue = properties?[i].GetValue(entity);

                // Part-one of sql-query
                if (i == countProperties - 1)
                    partOne.Append($"{propertyName}");
                else
                    partOne.Append($"{propertyName}, ");

                // Part-two of sql-query
                if (i == countProperties - 1)
                    partTwo.Append($"@{propertyName}");
                else
                    partTwo.Append($"@{propertyName}, ");

                // Part dynamicParameters
                dynamicParameters.Add($"{propertyName}", propertyValue);
            }

            string sqlQuery = $"INSERT INTO {tableName} ({partOne}) VALUES ({partTwo})";

            return (sqlQuery, dynamicParameters);
        }

        public static (string sqlQuery, DynamicParameters parameters) UpdateQuery<T>(this T entity, string tableName) where T : class
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            StringBuilder partOne = new StringBuilder();
            string partTwo = string.Empty;

            var properties = entity.GetType().GetProperties();
            int countProperties = properties.Length;

            for (int i = 0; i < countProperties; i++)
            {
                string propertyName = properties?[i].Name;
                var propertyValue = properties?[i].GetValue(entity);

                // Part-one of sql-query
                if (i == countProperties - 1)
                    partOne.Append($"{propertyName} = @{propertyName}");
                else
                    partOne.Append($"{propertyName} = @{propertyName}, ");

                // Part-two of sql-query
                if (propertyName == $"{tableName}Id")
                    partTwo = $"{propertyName} = @{propertyName}";

                // Part dynamicParameters
                dynamicParameters.Add($"{propertyName}", propertyValue);
            }

            string sqlQuery = $"UPDATE {tableName} SET {partOne} WHERE {partTwo}";

            return (sqlQuery, dynamicParameters);
        }

        public static (string sqlQuery, DynamicParameters parameters) GetByIdQuery(this Guid? entityId, string tableName)
        {
            string sqlQuery = $"SELECT * FROM {tableName} WHERE {tableName}Id = @{tableName}Id; ";

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"{tableName}Id", entityId.ToString());

            return (sqlQuery, dynamicParameters);
        }

        public static string GetAllQuery(this string tableName)
        {
            string sqlQuery = $"SELECT * FROM {tableName} ORDER BY {tableName}Name";

            return sqlQuery;
        }

        public static (string sqlQuery, DynamicParameters parameters) DeleteQuery(this Guid entityId, string tableName)
        {
            string sqlQuery = $"DELETE FROM {tableName} WHERE {tableName}Id = @{tableName}Id; ";

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"{tableName}Id", entityId.ToString());

            return (sqlQuery, dynamicParameters);
        }

        public static (string sqlQuery, DynamicParameters parameters) ValidateNameQuery(this string tableName, string entityName)
        {
            string sqlQuery = $"SELECT * FROM {tableName} WHERE {tableName}Name = @{tableName}Name;";

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"{tableName}Name", entityName);

            return (sqlQuery, dynamicParameters);
        }

        #region Fee table
        public static (string sqlQuery, DynamicParameters parameters) FeePaginationQuery(this SearchFeeResource search)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.AppendLine("SELECT * FROM Fee WHERE 1 = 1");

            if (!string.IsNullOrEmpty(search.FeeName))
            {
                sqlQuery.AppendLine("AND FeeName LIKE @FeeName");
                dynamicParameters.Add("FeeName", $"%{search.FeeName}%");

                if (!search.Follow)
                {
                    sqlQuery.AppendLine("AND Follow = @Follow");
                    dynamicParameters.Add("Follow", 0);
                }
            }
            else
            {
                if (!search.Follow)
                {
                    sqlQuery.AppendLine("AND Follow = @Follow");
                    dynamicParameters.Add("Follow", 0);
                }
            }

            if (search.FeeGroupId != null)
            {
                sqlQuery.AppendLine("AND FeeGroupId = @FeeGroupId");
                dynamicParameters.Add("FeeGroupId", search.FeeGroupId);
            }

            if (search.FeeRangeId != null)
            {
                sqlQuery.AppendLine("AND FeeRangeId = @FeeRangeId");
                dynamicParameters.Add("FeeRangeId", search.FeeRangeId);
            }

            if (search.TurnFeeId != null)
            {
                sqlQuery.AppendLine("AND TurnFee = @TurnFee");
                dynamicParameters.Add("TurnFee", search.TurnFeeId);
            }

            if (search.AmountOfFee != null)
            {
                sqlQuery.AppendLine("AND AmountOfFee = @AmountOfFee");
                dynamicParameters.Add("AmountOfFee", search.AmountOfFee);
            }

            sqlQuery.AppendLine("ORDER BY FeeName");

            sqlQuery.AppendLine("LIMIT @LIMIT");
            dynamicParameters.Add("LIMIT", search.PageSize);

            sqlQuery.AppendLine("OFFSET @OFFSET");
            dynamicParameters.Add("OFFSET", (search.Page - 1) * search.PageSize);

            return (sqlQuery.ToString(), dynamicParameters);
        }

        public static (string sqlQuery, DynamicParameters parameters) FeeTotalRecordsQuery(this SearchFeeResource search)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.AppendLine("SELECT COUNT(*) FROM Fee WHERE 1 = 1");

            if (!string.IsNullOrEmpty(search.FeeName))
            {
                sqlQuery.AppendLine("AND FeeName LIKE @FeeName");
                dynamicParameters.Add("FeeName", $"%{search.FeeName}%");

                if (!search.Follow)
                {
                    sqlQuery.AppendLine("AND Follow = @Follow");
                    dynamicParameters.Add("Follow", 0);
                }
            }
            else
            {
                if (!search.Follow)
                {
                    sqlQuery.AppendLine("AND Follow = @Follow");
                    dynamicParameters.Add("Follow", 0);
                }
            }

            if (search.FeeGroupId != null)
            {
                sqlQuery.AppendLine("AND FeeGroupId = @FeeGroupId");
                dynamicParameters.Add("FeeGroupId", search.FeeGroupId);
            }

            if (search.FeeRangeId != null)
            {
                sqlQuery.AppendLine("AND FeeRangeId = @FeeRangeId");
                dynamicParameters.Add("FeeRangeId", search.FeeRangeId);
            }

            if (search.TurnFeeId != null)
            {
                sqlQuery.AppendLine("AND TurnFee = @TurnFee");
                dynamicParameters.Add("TurnFee", search.TurnFeeId);
            }

            if (search.AmountOfFee != null)
            {
                sqlQuery.AppendLine("AND AmountOfFee = @AmountOfFee");
                dynamicParameters.Add("AmountOfFee", search.AmountOfFee);
            }

            return (sqlQuery.ToString(), dynamicParameters);
        }
        #endregion
    }
}
