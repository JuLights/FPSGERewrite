using FPSGERewrite.DataService.Data;
using FPSGERewrite.Domain.Entities;
using FPSGERewrite.Infrastructure.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPSGERewrite.Infrastructure.DataAccess.Repositories
{
    public class KeyboardRepeository : GenericRepository<Keyboard>, IKeyboardRepository
    {
        public KeyboardRepeository(AppDbContext appDbContext, ILogger logger) : base(appDbContext, logger)
        {
        }

        public async override Task<Keyboard?> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await _dbSet.Where(x => x.KeyboardId == id).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Repo {nameof(KeyboardRepeository)} {nameof(GetByIdAsync)} function Error");
                throw;
            }
        }

        public async override Task<IEnumerable<Keyboard>?> AllAsync()
        {

            try
            {
                var result = await _dbSet.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Repo {nameof(KeyboardRepeository)} {nameof(AllAsync)} function Error");
                throw;
            }
        }
    }
}
