using FPSGERewrite.Application.Query;
using FPSGERewrite.Domain.Entities;
using FPSGERewrite.Infrastructure.DataAccess.Repositories.Interfaces;
using MediatR;

namespace FPSGERewrite.Api.Handlers
{
    public class GetAllKeyboardQueryHandler : IRequestHandler<GetAllKeyboardQuery, IEnumerable<Keyboard>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllKeyboardQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Keyboard>> Handle(GetAllKeyboardQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.KeyboardRepository.AllAsync();

            return result;
        }
    }
}
