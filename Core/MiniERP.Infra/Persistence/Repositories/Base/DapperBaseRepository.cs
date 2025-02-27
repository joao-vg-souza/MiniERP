using MiniERP.Domain.Repositories.Base;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;

namespace MiniERP.Infra.Persistence.Repositories.Base
{
    public class DapperBaseRepository : IBaseRepository
    {
        private readonly string _connString;

        public DapperBaseRepository(string connString)
        {
            _connString = connString;
        }

        public async Task DeleteAsync<T>(Guid id)
        {
            using SqlConnection connection = new(_connString);
            var tableName = GetTableName<T>();
            var query = $"DELETE FROM dbo.{tableName} WHERE Codigo = @Id";
            await connection.ExecuteAsync(query, new { Id = id });
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            using SqlConnection connection = new(_connString);
            var tableName = GetTableName<T>();

            var query = $"SELECT * FROM dbo.{tableName}";
            return await connection.QueryAsync<T>(query);
        }

        public async Task<T?> GetByIdAsync<T>(Guid id)
        {
            using SqlConnection connection = new(_connString);
            var tableName = GetTableName<T>();

            var query = $"SELECT * FROM dbo.{tableName} WHERE Codigo = @Id";
            return await connection.QueryFirstOrDefaultAsync<T>(query, new { Id = id });
        }

        public async Task<int> InsertAsync<T>(T entity)
        {
            using SqlConnection connection = new(_connString);
            var tableName = GetTableName<T>();

            var query = $"INSERT INTO dbo.{tableName} ({GetColumns<T>()}) OUTPUT INSERTED.Id VALUES ({GetColumnsParams<T>()})";
            return await connection.ExecuteScalarAsync<int>(query, entity);
        }

        public async Task UpdateAsync<T>(T entity)
        {
            using SqlConnection connection = new(_connString);
            var tableName = GetTableName<T>();

            var query = $"UPDATE dbo.{tableName} SET {GetUpdateColumns<T>()} WHERE Codigo = @Codigo";
            await connection.ExecuteAsync(query, entity);
        }

        private string GetColumns<T>()
        {
            var properties = typeof(T).GetProperties()
                .Where(p => p.Name != "Id")
                .Select(p => p.Name);
            return string.Join(", ", properties);
        }

        private string GetColumnsParams<T>()
        {
            var properties = typeof(T).GetProperties()
                .Where(p => p.Name != "Id")
                .Select(p => "@" + p.Name);
            return string.Join(", ", properties);
        }

        private string GetUpdateColumns<T>()
        {
            var properties = typeof(T).GetProperties()
                .Where(p => p.Name != "Codigo" && p.Name != "Id" && p.Name != "DtInclusao")
                .Select(p => $"{p.Name} = @{p.Name}");
            return string.Join(", ", properties);
        }

        private string GetTableName<T>()
        {
            string tableName = typeof(T).Name;

            return tableName;
        }
    }
}
