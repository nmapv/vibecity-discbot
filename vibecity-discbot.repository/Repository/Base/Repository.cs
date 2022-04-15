﻿using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace vibecity_discbot.repository.Repository.Base
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected IDBContext _dbcontext;

        public Repository(IDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task InsertAsync(TEntity entity)
        {
            await _dbcontext.connection.InsertAsync(entity);
        }

        public async Task InsertListAsync(IEnumerable<TEntity> entities)
        {
            await _dbcontext.connection.InsertAsync(entities);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await _dbcontext.connection.DeleteAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbcontext.connection.GetAllAsync<TEntity>();
        }

        public async Task<TEntity> GetAsync(long id)
        {
            return await _dbcontext.connection.GetAsync<TEntity>(id);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _dbcontext.connection.UpdateAsync(entity);
        }
    }
}
