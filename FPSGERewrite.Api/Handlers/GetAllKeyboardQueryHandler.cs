using FPSGERewrite.Api.Query;
using FPSGERewrite.DataService.Repositories.Interfaces;
using FPSGERewrite.Entities.DbSet;
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
