using FPSGERewrite.DataService.Data;
using FPSGERewrite.DataService.Repositories.Interfaces;
using FPSGERewrite.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPSGERewrite.DataService.Repositories
{
    public class MouseRepository : GenericRepository<Mouse>, IMouseRepository
    {
        public MouseRepository(AppDbContext appDbContext, ILogger logger) : base(appDbContext, logger)
        {
        }

        public async override Task<Mouse?> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await _dbSet.Where(x => x.MouseId == id).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Repo {nameof(MouseRepository)} {nameof(GetByIdAsync)} function Error");
                throw;
            }
        }

        public async override Task<IEnumerable<Mouse>?> AllAsync()
        {
            try
            {
                var result = await _dbSet.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Repo {nameof(MouseRepository)} {nameof(AllAsync)} function Error");
                throw;
            }
        }

    }
}
