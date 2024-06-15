using FPSGERewrite.Application.Query;
using FPSGERewrite.Domain.Entities;
using FPSGERewrite.Application.Dtos.Response;
using FPSGERewrite.Infrastructure.DataAccess.Repositories.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FPSGERewrite.Api.Handlers
{
    public class GetMouseQueryHandler : IRequestHandler<GetMouseQuery, MouseResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        public GetMouseQueryHandler(IUnitOfWork unitOfWork, ILoggerFactory logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger.CreateLogger("MouseHandler-Logs");
        }
        public async Task<MouseResponse> Handle(GetMouseQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var mouse = await _unitOfWork.MouseRepository.GetByIdAsync(request.Id);
                if (mouse != null)
                {
                    var productList = await _unitOfWork.ProductRepository.AllAsync();
                    var product = productList.Where(x => x.MouseId == mouse.MouseId).FirstOrDefault();


                    return new MouseResponse
                    {
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        ProductCondition = product.ProductCondition,
                        ProductDescription = product.ProductDescription,
                        Price = product.Price,
                        AddedDate = product.AddedDate,
                        UpdatedDate = product.UpdatedDate,

                        MouseId = mouse.MouseId,
                        AdditionalKeys = mouse.AdditionalKeys,
                        Brand = mouse.Brand,
                        Color = mouse.Color,
                        SensorType = mouse.SensorType,
                        RGB = mouse.RGB,
                    };
                }
                else
                {
                    return null;
                }
                

            }
            catch (Exception ex)
            {
                _logger.LogError($"Handler {nameof(GetMouseQueryHandler)} Handler function Error {ex.Message + ex.InnerException}");
                throw;
            }

            
        }
    }
}
