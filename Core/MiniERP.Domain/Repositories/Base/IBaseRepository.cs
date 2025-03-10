﻿namespace MiniERP.Domain.Repositories.Base
{
    public interface IBaseRepository
    {
        Task<IEnumerable<T>> GetAllAsync<T>();
        Task<T?> GetByIdAsync<T>(Guid id);
        Task<int> InsertAsync<T>(T entity);
        Task UpdateAsync<T>(T entity);
        Task DeleteAsync<T>(Guid id);
        Task BulkInsertAsync<T>(IEnumerable<T> entities);

        Task <IEnumerable<T>> RawQueryAsync<T>(string query, object? param);
    }
}
