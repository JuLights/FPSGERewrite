using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPSGERewrite.Software.Services
{
    interface IProductService
    {
        public Task<List<FPSGERewrite.Software.Models.Keyboard>> GetProductsAsync(string uri);
    }
}
