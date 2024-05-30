using FPSGERewrite.Application.Commands;
using FPSGERewrite.Domain.Entities;
using FPSGERewrite.Application.Dtos.Request;
using FPSGERewrite.Infrastructure.DataAccess.Repositories.Interfaces;
using MediatR;

namespace FPSGERewrite.Api.Handlers
{
    public class AddKeyboardCommandHandler : IRequestHandler<AddKeyboardCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddKeyboardCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(AddKeyboardCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                AddedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                ProductName = request.CreateKeyboardRequest.ProductName,
                ProductCondition = request.CreateKeyboardRequest.ProductCondition,
                ProductDescription = request.CreateKeyboardRequest.ProductDescription,
                Price = request.CreateKeyboardRequest.Price,
                Keyboard = new Keyboard
                {
                    RGB = request.CreateKeyboardRequest.RGB,
                    Color = request.CreateKeyboardRequest.Color,
                    Brand = request.CreateKeyboardRequest.Brand,
                    CableLength = request.CreateKeyboardRequest.CableLength,
                    SwitchType = request.CreateKeyboardRequest.SwitchType
                },
            };

            await _unitOfWork.ProductRepository.AddAsync(product);

            var result = await _unitOfWork.CompleteAsync();

            return result;
        }
    }

}
