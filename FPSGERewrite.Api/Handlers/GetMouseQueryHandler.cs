using FPSGERewrite.Api.Query;
using FPSGERewrite.DataService.Repositories.Interfaces;
using FPSGERewrite.Entities.DbSet;
using MediatR;

namespace FPSGERewrite.Api.Handlers
{
    public class GetMouseQueryHandler : IRequestHandler<GetMouseQuery, Mouse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetMouseQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Mouse> Handle(GetMouseQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.MouseRepository.GetByIdAsync(request.Id);

            return result;
        }
    }
}
