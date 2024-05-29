using FPSGERewrite.Api.Commands;
using FPSGERewrite.DataService.Repositories.Interfaces;
using FPSGERewrite.Entities.DbSet;
using MediatR;

namespace FPSGERewrite.Api.Handlers
{
    public class AddMouseCommandHandler : IRequestHandler<AddMouseCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddMouseCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(AddMouseCommand request, CancellationToken cancellationToken)
        {
            var mouse = new Mouse();
            mouse.RGB = request.CreateMouseRequest.RGB;
            mouse.AdditionalKeys = request.CreateMouseRequest.AdditionalKeys;
            mouse.Color = request.CreateMouseRequest.Color;
            mouse.Brand = request.CreateMouseRequest.Brand;
            mouse.SensorType = request.CreateMouseRequest.SensorType;

            var product = new Product
            {
                AddedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                ProductName = request.CreateMouseRequest.ProductName,
                ProductCondition = request.CreateMouseRequest.ProductCondition,
                ProductDescription = request.CreateMouseRequest.ProductDescription,
                Price = request.CreateMouseRequest.Price,
                Mouse = new Mouse
                {
                    RGB = request.CreateMouseRequest.RGB,
                    AdditionalKeys = request.CreateMouseRequest.AdditionalKeys,
                    Color = request.CreateMouseRequest.Color,
                    Brand = request.CreateMouseRequest.Brand,
                    SensorType = request.CreateMouseRequest.SensorType
                },
            };

            await _unitOfWork.ProductRepository.AddAsync(product);
            var result = await _unitOfWork.CompleteAsync();
            return result;
        }
    }
}
