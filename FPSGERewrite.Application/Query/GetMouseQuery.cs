using FPSGERewrite.Application.Dtos.Response;
using MediatR;

namespace FPSGERewrite.Application.Query
{
    public class GetMouseQuery : IRequest<MouseResponse>
    {
        public Guid Id;
        public GetMouseQuery(Guid id)
        {
            Id = id;
        }
    }
}
