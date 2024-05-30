using FPSGERewrite.DataService.Data;
using FPSGERewrite.Infrastructure.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPSGERewrite.Infrastructure.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _appDbContext;
        protected readonly ILogger _logger;
        internal DbSet<T> _dbSet;
        public GenericRepository(AppDbContext appDbContext, ILogger logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
            _dbSet = _appDbContext.Set<T>();
        }
        public virtual async Task<bool> AddAsync(T entity)
        {
            var result = await _dbSet.AddAsync(entity);

            return true;
        }

        public virtual Task<IEnumerable<T>?> AllAsync()
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<T?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
