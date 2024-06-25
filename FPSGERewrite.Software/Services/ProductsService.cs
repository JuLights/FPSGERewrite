using FPSGERewrite.Software.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPSGERewrite.Software.Services
{
    public class ProductsService : IProductService
    {
        private List<FPSGERewrite.Software.Models.Keyboard> Keyboards { get; set; }
        private bool isFetched = false;
        public ProductsService() 
        {
        }

        async Task<List<FPSGERewrite.Software.Models.Keyboard>> FetchProduct(string uri)
        {
            using (var client = new HttpClient())
            {
                using HttpResponseMessage response =  await client.GetAsync(uri);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if(content is not null)
                    {
                        Keyboards = JsonConvert.DeserializeObject<List<FPSGERewrite.Software.Models.Keyboard>>(content);
                        Keyboards?.Reverse();
                        return Keyboards;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<List<FPSGERewrite.Software.Models.Keyboard>> GetProductsAsync(string uri)
        {
            if (isFetched)
            {
                return Keyboards;
            }
            else
            {
                return await FetchProduct(uri);
            }
            
        }
    }
}
