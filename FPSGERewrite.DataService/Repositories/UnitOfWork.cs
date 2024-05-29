using FPSGERewrite.DataService.Data;
using FPSGERewrite.DataService.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPSGERewrite.DataService.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _appDbContext;
        protected readonly ILogger _logger;
        public IProductRepository ProductRepository { get; }

        public IMouseRepository MouseRepository { get; }

        public IKeyboardRepository KeyboardRepository { get; }

        public UnitOfWork(AppDbContext appDbContext, ILoggerFactory loggerFactory)
        {
            _appDbContext = appDbContext;
            _logger = loggerFactory.CreateLogger("logs");
            ProductRepository = new ProductRepository(_appDbContext, _logger);
            MouseRepository = new MouseRepository(_appDbContext, _logger);
            KeyboardRepository = new KeyboardRepeository(_appDbContext, _logger);
        }

        public async Task<bool> CompleteAsync()
        {
            var result = await _appDbContext.SaveChangesAsync();
            if (result > 0)
                return true;
            else
                return false;
        }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }
    }
}
