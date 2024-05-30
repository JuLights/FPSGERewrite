using FPSGERewrite.Application.Query;
using FPSGERewrite.Infrastructure.DataAccess.Repositories;
using FPSGERewrite.Domain.Entities;
using FPSGERewrite.Application.Dtos.Response;
using FPSGERewrite.Infrastructure.DataAccess.Repositories.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FPSGERewrite.Api.Handlers
{
    public class GetKeyboardQueryHandler : IRequestHandler<GetKeyboardQuery, KeyboardResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        public GetKeyboardQueryHandler(IUnitOfWork unitOfWork, ILoggerFactory logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger.CreateLogger("KeyboardHandler-Logs");
        }

        public async Task<KeyboardResponse> Handle(GetKeyboardQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var keyboard = await _unitOfWork.KeyboardRepository.GetByIdAsync(request.Id);
                var productList = await _unitOfWork.ProductRepository.AllAsync();
                var product = productList.Where(x => x.KeyboardId == keyboard.KeyboardId).FirstOrDefault();

                return new KeyboardResponse
                {
                    ProductName = product.ProductName,
                    ProductCondition = product.ProductCondition,
                    ProductDescription = product.ProductDescription,
                    ProductId = product.ProductId,
                    AddedDate = product.AddedDate,
                    UpdatedDate = product.UpdatedDate,
                    Price = product.Price,
                    KeyboardId = keyboard.KeyboardId,
                    Color = keyboard.Color,
                    Brand = keyboard.Brand,
                    CableLength = keyboard.CableLength,
                    RGB = keyboard.RGB,
                    SwitchType = keyboard.SwitchType,
                };
            }
            catch(Exception ex) 
            {
                _logger.LogError($"Handler {nameof(GetKeyboardQueryHandler)} Handler function Error {ex.Message + ex.InnerException}");
                throw;
            }
            
        }
    }
}
