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
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext appDbContext, ILogger logger) : base(appDbContext, logger)
        {
        }

        public async override Task<IEnumerable<Product>?> AllAsync()
        {
            try
            {

                return await _dbSet.ToListAsync();

            }catch(Exception ex) {

                _logger.LogError($"Repo {nameof(ProductRepository)} All function Error");
                throw;
            }
            
        }

        public async override Task<Product?> GetByIdAsync(Guid id)
        {
            try
            {
                return await _dbSet.Where(x=>x.ProductId == id).FirstOrDefaultAsync();

            }catch(Exception ex)
            {
                _logger.LogError($"Repo {nameof(ProductRepository)} GetByIdAsync function Error");
                throw;
            }
        }

        public async override Task<bool> UpdateAsync(Product product)
        {
            try
            {
                var result = await _dbSet.Where(x => x.ProductId == product.ProductId).FirstOrDefaultAsync();
                //result.RGB = product.RGB;
                //result.Color = product.Color;
                //result.Brand = product.Brand;
                result.ProductCondition = product.ProductCondition;
                result.ProductName = product.ProductName;
                result.ProductDescription = product.ProductDescription;
                result.UpdatedDate = product.UpdatedDate;
                result.Price = product.Price;

                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Repo {nameof(ProductRepository)}, {nameof(UpdateAsync)} function Error");
                throw;
            }
        }

        public async override Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dbSet.Where(x => x.ProductId == id).FirstOrDefaultAsync();
                _dbSet.Remove(result);

                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Repo {nameof(ProductRepository)}, {nameof(DeleteAsync)} function Error");
                throw;
            }
        }
    }
}
