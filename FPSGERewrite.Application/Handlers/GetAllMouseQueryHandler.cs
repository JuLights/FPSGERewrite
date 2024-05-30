using FPSGERewrite.Application.Query;
using FPSGERewrite.Domain.Entities;
using FPSGERewrite.Infrastructure.DataAccess.Repositories.Interfaces;
using MediatR;

namespace FPSGERewrite.Api.Handlers
{
    public class GetAllMouseQueryHandler : IRequestHandler<GetAllMouseQuery, IEnumerable<Mouse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllMouseQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Mouse>> Handle(GetAllMouseQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.MouseRepository.AllAsync();

            return result;
        }
    }
}
