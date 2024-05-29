using FPSGERewrite.Api.Query;
using FPSGERewrite.DataService.Repositories.Interfaces;
using FPSGERewrite.Entities.DbSet;
using MediatR;

namespace FPSGERewrite.Api.Handlers
{
    public class GetKeyboardQueryHandler : IRequestHandler<GetKeyboardQuery, Keyboard>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetKeyboardQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Keyboard> Handle(GetKeyboardQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.KeyboardRepository.GetByIdAsync(request.Id);
            return result;
        }
    }
}
